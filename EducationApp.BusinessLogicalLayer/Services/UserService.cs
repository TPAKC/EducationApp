using EducationApp.BusinessLogicalLayer.Helpers;
using EducationApp.BusinessLogicalLayer.Models;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Models.Account;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicalLayer.Common.Constants.AccountRole;
using static EducationApp.BusinessLogicalLayer.Common.Constants.ServiceValidationErrors;
using static EducationApp.BusinessLogicalLayer.Common.Constants.TemplateText;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly Mapper _mapper;
        private readonly JwtHelper _jwtHelper;
        private readonly JwtOptions _jwtOptions;
        private readonly EmailHelper _emailHelper;
        //todo inject IEmailHelper +
        public UserService(IUserRepository userRepository, 
            Mapper mapper, 
            JwtHelper jwtHelper,     
            IOptions<JwtOptions> jwtOptions, 
            EmailHelper emailHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            _jwtOptions = jwtOptions.Value;
            _emailHelper = emailHelper;
        }

        public async Task<LoginView> Login(string email, string password, bool rememberMe)
        {
            LoginView modelResult = new LoginView();
            var user = await _userRepository.FindByEmailAsync(email);
            if(user == null)
            {
                modelResult.Errors.Add(ThisEmailAddressIsNotRegistered);
                return modelResult;
            }
            if (user.IsBlocked)
            {
                modelResult.Errors.Add(ThisAccountIsBlocked);
                return modelResult;
            }
            if (user.IsRemoved)
            {
                modelResult.Errors.Add(ThisAccountIsRemoved);
                return modelResult;
            }
            if (!user.EmailConfirmed)
            {
                modelResult.Errors.Add(ThisEmailIsNotVerified);
                return modelResult;
            }
            var isSignIn = await _userRepository.PasswordSignInAsync(user, password, rememberMe);
            if (!isSignIn)
            {
                modelResult.Errors.Add(PasswordIsIncorrect);
                return modelResult;
            }

            /*var result = new LoginView();
            result.UserId = user.Id;
            result.Confirmed = user.EmailConfirmed;
            if (user.EmailConfirmed)
            {
                result.Token = await GetAccessToken(user);
            }*/

            return modelResult;
        }

        public async Task<UserModelItem> CreateAsync(CreateUserModel createModel)
        {
            var resultModel = new UserModelItem();
            var user = await _userRepository.FindByEmailAsync(createModel.Email);
            if (user != null)
            {
                resultModel.Errors.Add(UserIsExist);
                return resultModel;
            }
            var newUser = _mapper.RegisterModelToApplicationUser(createModel);
            var result = await _userRepository.CreateAsync(newUser, createModel.Password);
            if (!result)
            {
                resultModel.Errors.Add(UserCantBeRegistered);
                return resultModel;
            }

            result = await _userRepository.AddToRoleAsync(newUser, NameUserRole); //todo errors and roles from constants or enums +
            if (!result)
            {
                resultModel.Errors.Add(UserCantBeAddedToRole);
            }
            resultModel.Id = newUser.Id;
            return resultModel;
        }

        public async Task<BaseModel> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel)
        {
            var resultModel = new BaseModel();
            if (changePasswordViewModel == null) 
            {
                resultModel.Errors.Add(ModelIsNotValid);
                return resultModel;
            }

            var user = await _userRepository.FindByEmailAsync(changePasswordViewModel.Email);
            if (user == null)
            {
                resultModel.Errors.Add(UserIsExist);
                return resultModel;
            }

            var result = await _userRepository.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword); //you may need to enter the password manually
            if (!result)
            {
                resultModel.Errors.Add(FailedToChangePassword);
            }

            return resultModel;
        }

        public async Task<BaseModel> DeleteAsync(string id)
        {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null)
            {
                resultModel.Errors.Add(UserIsExist);
                return resultModel;
            }
            user.IsRemoved = true;
            await _userRepository.UpdateAsync(user);
            return resultModel;
        }

    public async Task<BaseModel> UpdateAsync(UserModelItem userModel)
    { 
            var resultModel = new BaseModel();
            if (userModel == null)
            {
                resultModel.Errors.Add(ModelIsNotValid);
            }

            var user = await _mapper.UserModelITemToApplicationUser(userModel);
            if (user == null)
            {
                resultModel.Errors.Add(UserIsExist);
                return resultModel;
            }

            var result = await _userRepository.UpdateAsync(user);
            if (!result)
            {
                resultModel.Errors.Add(FailedToUpdateUser);
            }

            return resultModel;
    }

    public UserModel GetUsersAsync(bool isActive, bool isBlocked, int numberSortState)
    {
            var usersResultModel = new UserModel();
            var sortState = (SortStateUsers)numberSortState;
            var users = _userRepository.GetUsersAsync(isActive, isBlocked, sortState);
        if(users == null)
            {
                usersResultModel.Errors.Add(ListRetrievalError);
                return usersResultModel;
            }

         usersResultModel.Users = users.Select(user => _mapper.ApplicationUserToUserModelITem(user)).ToList();
            return usersResultModel;
        }

    public async Task SignOutAsync()
    {
            await _userRepository.SignOutAsync();
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(string email)
    {
            var user = await _userRepository.FindByEmailAsync(email);
            return await _userRepository.GenerateEmailConfirmationTokenAsync(user);
    }

    public async Task<BaseModel> ConfirmEmailAsync(string id, string code)
    {
        var resultModel = new BaseModel();
        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(code))
        {
            resultModel.Errors.Add(WrongInputData); //todo from const +
            return resultModel;
        }
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null)
        {
            resultModel.Errors.Add(UserNotFound); //todo from const +
            return resultModel;
        }
        var confirmResult = await _userRepository.ConfirmEmailAsync(user, code);
        if (!confirmResult)
        {
            resultModel.Errors.Add(UserNotConfirmed); //todo from const +
        }
        return resultModel;
    }

    public async Task<BaseModel> ForgotPassword(string email)
    {
            var resultModel = new BaseModel();
            var newPassword = GeneratePassword();
            var user = await _userRepository.FindByEmailAsync(email);
            if(user==null)
            {
                resultModel.Errors.Add(UserWithThisMailNotFound);
                return resultModel;
            }
            var result = await _userRepository.IsEmailConfirmedAsync(user);
            if (!result)
            {
                resultModel.Errors.Add(UserNotConfirmed);
                return resultModel;
            }
            await _emailHelper.SendEmailAsync(email, "Reset Password", $"{ResetPasswordText}{newPassword}");
            var code = await _userRepository.GeneratePasswordResetTokenAsync(user);
            result = await _userRepository.ResetPasswordAsync(user, code, newPassword);
            if (!result)
            {
                resultModel.Errors.Add(FailedToResetPassword);
                return resultModel;
            }
            return resultModel;
        }

        private string GeneratePassword()
        {
            int[] arr = new int[8];
            Random random = new Random();
            string password = "";
            for (int i = 0; i < arr.Length; i++)
            {
                password += random.Next(0, 9);
            }
            return password;
        }

        private async Task<string> GetAccessToken(ApplicationUser user)
        {
            var roles = await _userRepository.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
            var token = await _jwtHelper.GenerateEncodedToken(user, role);
            return token;
        }

        public async Task<BaseModel> ChangeUserStatus(string id, bool userStatus)
        {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByIdAsync(id);
            if(user == null)
            {
                resultModel.Errors.Add(UserNotFound);
                return resultModel;
            }
            user.IsBlocked = userStatus;
            await _userRepository.UpdateAsync(user);
            return resultModel;
        } 
    } 
}

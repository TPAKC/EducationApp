﻿using EducationApp.BusinessLogicalLayer.Helpers.Interface;
using EducationApp.BusinessLogicalLayer.Helpers.Interfaces;
using EducationApp.BusinessLogicalLayer.Models;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Models.Account;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicalLayer.Constants.AccountRole;
using static EducationApp.BusinessLogicalLayer.Constants.ServiceValidationErrors;
using static EducationApp.BusinessLogicalLayer.Constants.TemplateText;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailHelper _emailHelper;
        private readonly IGeneratePasswordHelper _generatePasswordHelper;
        public UserService(IUserRepository userRepository,
            IMapper mapper,
            IEmailHelper emailHelper,
            IGeneratePasswordHelper generatePasswordHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;;
            _emailHelper = emailHelper;
            _generatePasswordHelper = generatePasswordHelper;
        }

        public async Task<LoginModel> LoginAsync(string email, string password, bool rememberMe)
        {
            var modelResult = new LoginModel();
            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null)
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
            return modelResult;
        }

        public async Task<UserModelItem> CreateAsync(RegistrationModel createModel)
        {
            var resultModel = new UserModelItem();
            var existingUser = await _userRepository.FindByEmailAsync(createModel.Email);
            if (existingUser != null)
            {
                resultModel.Errors.Add(UserIsExist);
                return resultModel;
            }
            var user = _mapper.RegisterModelToEntity(createModel);
            var result = await _userRepository.CreateAsync(user, createModel.Password);
            if (!result)
            {
                resultModel.Errors.Add(UserCantBeRegistered);
                return resultModel;
            }

            result = await _userRepository.AddToRoleAsync(user, RoleUser);
            if (!result)
            {
                resultModel.Errors.Add(UserCantBeAddedToRole);
            }
            resultModel.Id = user.Id;
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

            var result = await _userRepository.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);
            if (!result)
            {
                resultModel.Errors.Add(FailedToChangePassword);
            }

            return resultModel;
        }

        public async Task<BaseModel> DeleteAsync(long id)
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

            var user = _mapper.ModelItemToEntity(userModel);
            if (user == null)
            {
                resultModel.Errors.Add(UserIsExist);
                return resultModel;
            }
            if (!string.IsNullOrWhiteSpace(userModel.Pasword))
            {
                await _userRepository.ResetPasswordAsync(user, userModel.Pasword);
            }

            var result = await _userRepository.UpdateAsync(user);
            if (!result)
            {
                resultModel.Errors.Add(FailedToUpdateUser);
            }

            return resultModel;
        }

        public async Task<UserModel> GetSortedAsync(UsersManagmentModel usersManagmentModel)
        {
            var usersResultModel = new UserModel();
            var users = await _userRepository.FilteredAsync(usersManagmentModel);
            usersResultModel.Items = users.Select(user => _mapper.EntityToModelITem(user)).ToList();
            return usersResultModel;
        }

        public async Task LogOutAsync()
        {
            await _userRepository.LogOutAsync();
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(string email)
        {
            var user = await _userRepository.FindByEmailAsync(email);
            return await _userRepository.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<BaseModel> ConfirmEmailAsync(long id, string code)
        {
            var resultModel = new BaseModel();
            if (id == 0 || string.IsNullOrWhiteSpace(code))
            {
                resultModel.Errors.Add(WrongInputData); 
                return resultModel;
            }
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null)
            {
                resultModel.Errors.Add(UserNotFound);
                return resultModel;
            }
            var confirmResult = await _userRepository.ConfirmEmailAsync(user, code);
            if (!confirmResult)
            {
                resultModel.Errors.Add(UserNotConfirmed);
            }
            return resultModel;
        }

        public async Task<BaseModel> ForgotPasswordAsync(string email)
        {
            var resultModel = new BaseModel();
            var newPassword = _generatePasswordHelper.GeneratePassword();
            var user = await _userRepository.FindByEmailAsync(email);
            if (user == null)
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
            result = await _userRepository.ResetPasswordAsync(user, newPassword);
            if (!result)
            {
                resultModel.Errors.Add(FailedToResetPassword);
                return resultModel;
            }
            return resultModel;
        }

        public async Task<BaseModel> ChangeStatusAsync(long id, bool userStatus)
        {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null)
            {
                resultModel.Errors.Add(UserNotFound);
                return resultModel;
            }
            user.IsBlocked = userStatus;
            var result = await _userRepository.UpdateAsync(user);
            if(!result)
            {
                resultModel.Errors.Add(FailedToUpdateUser);
            }
            return resultModel;
        }
    }
}

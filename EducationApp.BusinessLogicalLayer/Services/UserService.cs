using EducationApp.BusinessLogicalLayer.Helpers;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicalLayer.Common.Constants.AccountRole;
using static EducationApp.BusinessLogicalLayer.Common.Constants.ServiceValidationErrors;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly Mapper _mapper;
        //todo inject IEmailHelper ?
        public UserService(IUserRepository userRepository, Mapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserModelItem> CreateAsync(CreateUserViewModel userModel)
        {
            var userResultModel = new UserModelItem();
            var user = await _userRepository.FindByEmailAsync(userModel.Email);
            if (user != null)
            {
                userResultModel.Errors.Add(UserIsExist);
                return userResultModel;
            }
            userResultModel = _mapper.ApplicationUserToUserModelITem(user); //todo map user to userResultModel +
            var result = await _userRepository.CreateAsync(user, userModel.Password);
            if (!result)
            {
                userResultModel.Errors.Add(UserCantBeRegistered);
                return userResultModel;
            }

            result = await _userRepository.AddToRoleAsync(user, NameUserRole); //todo errors and roles from constants or enums +
            if (!result)
            {
                userResultModel.Errors.Add(UserCantBeAddedToRole);
            }

            return userResultModel;
        }

        public async Task<BaseModel> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel)
        {
            var resultModel = new BaseModel();
            if (changePasswordViewModel == null) 
            {
                resultModel.Errors.Add(ModelIsExist);
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

            var result = await _userRepository.DeleteAsync(user);
            if (!result)
            {
                resultModel.Errors.Add(FailedToRemoveUser);
            }

            return resultModel;
        }

        public async Task<UserModelItem> FindByIdAsync(string id)
        {
            var userResultModel = new UserModelItem();
            var user = await _userRepository.FindByIdAsync(id);
            if(user == null) //todo check user for null +
            {
                userResultModel.Errors.Add(UserIsExist);
                return userResultModel;
            }
            userResultModel = _mapper.ApplicationUserToUserModelITem(user);
            return userResultModel; //todo map at mappers (Excention) +
        }

    public async Task<UserModelItem> FindByEmailAsync(string email)
    {
            var userResultModel = new UserModelItem();
            var user = await _userRepository.FindByEmailAsync(email);
        if(user == null)
            {
                userResultModel.Errors.Add(UserIsExist);
                return userResultModel;
            }
            userResultModel = _mapper.ApplicationUserToUserModelITem(user); //todo map at mappers +
            return userResultModel;
    }

    public async Task<BaseModel> UpdateAsync(UserModelItem userModel)
    {
            var resultModel = new BaseModel();
            if (userModel == null)
            {
                resultModel.Errors.Add(ModelIsExist);
            }

            ApplicationUser user = await _userRepository.FindByEmailAsync(userModel.Email);
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

    public UserModel GetUsersAsync()
    {
            var usersResultModel = new UserModel();
            var users = _userRepository.GetUsersAsync();
        if(users == null)
            {
                usersResultModel.Errors.Add(FailedToUpdateUser);
                return usersResultModel;
            }

         usersResultModel.Users = users.Select(user => _mapper.ApplicationUserToUserModelITem(user)).ToList();
            return usersResultModel;
        }

    public async Task<BaseModel> AddToRoleAsync(UserModelItem userModel, string role)
    {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByEmailAsync(userModel.Email);
            if (user == null)
            {
                resultModel.Errors.Add(FailedToUpdateUser);
                return resultModel;
            }
            var result = await _userRepository.AddToRoleAsync(user, role);
            if (!result)
            {
                resultModel.Errors.Add(UserCantBeAddedToRole);
            }
            return resultModel;
        }

    public async Task<BaseModel> RemoveFromRoleAsync(UserModelItem userModel, string role)
    {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByEmailAsync(userModel.Email);
         await _userRepository.RemoveFromRoleAsync(user, role);
            return resultModel;
    }

    public async Task<bool> IsEmailConfirmedAsync(UserModelItem userModel)
    {
        var user = await _userRepository.FindByEmailAsync(userModel.Email);
        return await _userRepository.IsEmailConfirmedAsync(user);
    }

    public async Task<SignInResult> PasswordSignInAsync(string id, string password, bool isPersistent)
    {
        var user = await _userRepository.FindByIdAsync(id);
        return await _userRepository.PasswordSignInAsync(user, password, isPersistent);
    }

    public async Task<BaseModel> SignOutAsync()
    {
            var resultModel = new BaseModel();
            await _userRepository.SignOutAsync();
            return resultModel;
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

    public async Task<BaseModel> ResetPasswordAsync(string email, string code, string password)
    {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByEmailAsync(email);
            var result = await _userRepository.ResetPasswordAsync(user, code, password);
            if(!result)
            {
                resultModel.Errors.Add(FailedToResetPassword);
            }
            return resultModel;
    }
    public async Task<string> GeneratePasswordResetTokenAsync(string email)
    {
        var user = await _userRepository.FindByEmailAsync(email);
        /* if (user == null || !(await _userRepository.IsEmailConfirmedAsync(user)))
         {
             return Ok("ForgotPasswordConfirmation");
         }*/
        return await _userRepository.GeneratePasswordResetTokenAsync(user);
    }
} 
}

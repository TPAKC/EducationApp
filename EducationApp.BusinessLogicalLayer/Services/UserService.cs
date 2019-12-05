using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicalLayer.Common.Constants.AccountRole;
using static EducationApp.BusinessLogicalLayer.Common.Constants.ServiceValidationErrors;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        //todo inject IEmailHelper
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            user = new ApplicationUser
            {
                Email = userModel.Email,
                UserName = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };
            var result = await _userRepository.CreateAsync(user, userModel.Password);
            user = await _userRepository.FindByEmailAsync(userModel.Email);
            //todo map user to userResultModel
            if (!result.Succeeded)
            {
                userResultModel.Errors.Add(UserCantBeRegistered);
                return userResultModel;
            }
            result = await _userRepository.AddToRoleAsync(user, NameUserRole); //todo errors and roles from constants or enums +
            if (!result.Succeeded)
            {
                userResultModel.Errors.Add(UserCantBeAddedToRole);
            }
            return userResultModel;
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel)
        {
            if (changePasswordViewModel != null)
            {
                //...
            }
            var user = await _userRepository.FindByEmailAsync(changePasswordViewModel.Email);
            return await _userRepository.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword); //you may need to enter the password manually
        }

        public async Task<IdentityResult> DeleteAsync(string id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            return await _userRepository.DeleteAsync(user);
        }

        public async Task<UserModelItem> FindByIdAsync(string id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            //todo check user for null
            var model = new UserModelItem(); //todo map at mappers (Excention)
            model.Email = user.Email;
            model.Id = user.Id;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            return model;
        }

    public async Task<UserModelItem> FindByEmailAsync(string email)
    {
        var user = await _userRepository.FindByEmailAsync(email);
        var model = new UserModelItem { Email = user.Email, Id = user.Id, FirstName = user.FirstName, LastName = user.LastName };
        return model;
    }

    public async Task<IdentityResult> UpdateAsync(UserModelItem userModel)
    {
        ApplicationUser user = await _userRepository.FindByEmailAsync(userModel.Email);
        return await _userRepository.UpdateAsync(user);
    }

    public List<UserModelItem> GetUsersAsync()
    {
        var users = _userRepository.GetUsersAsync();
        var models = users.Select(user => new UserModelItem
        {
            Email = user.Email,
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName
        }).ToList();

        return models;
    }

    public async Task<IdentityResult> AddToRoleAsync(UserModelItem userModel, string role)
    {
        var user = await _userRepository.FindByEmailAsync(userModel.Email);
        return await _userRepository.AddToRoleAsync(user, role);
    }

    public async Task<IList<string>> GetRolesAsync(UserModelItem userModel)
    {
        var user = await _userRepository.FindByEmailAsync(userModel.Email);
        return await _userRepository.GetRolesAsync(user);
    }

    public async Task<bool> IsInRoleAsync(UserModelItem userModel, string role)
    {
        var user = await _userRepository.FindByEmailAsync(userModel.Email);
        return await _userRepository.IsInRoleAsync(user, role);
    }

    public async Task<IdentityResult> RemoveFromRoleAsync(UserModelItem userModel, string role)
    {
        var user = await _userRepository.FindByEmailAsync(userModel.Email);
        return await _userRepository.RemoveFromRoleAsync(user, role);
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
        if (!confirmResult.Succeeded)
        {
            resultModel.Errors.Add(UserNotConfirmed); //todo from const +
        }
        return resultModel;
    }

    public async Task<IdentityResult> ResetPasswordAsync(string email, string code, string password)
    {
        return await _userRepository.ResetPasswordAsync(email, code, password);
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

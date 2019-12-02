using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services
{
    class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(UserModelItem userModel)
        {
            ApplicationUser user = await _userRepository.FindByEmailAsync(userModel.Email);
            user = new ApplicationUser { Email = userModel.Email, UserName = userModel.Email };
            var result = await _userRepository.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException("Create user error.");
            }
            await _userRepository.AddToRoleAsync(user, userModel.Role);
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel)
        {
            //handle the exception
            ApplicationUser user = await _userRepository.FindByEmailAsync(changePasswordViewModel.Email);
            return await _userRepository.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword); //you may need to enter the password manually
        }

        public async Task<IdentityResult> DeleteAsync(string id)
        {
            ApplicationUser user = await _userRepository.FindByIdAsync(id);
            return await _userRepository.DeleteAsync(user); 
        }

        public async Task<UserModelItem> FindByIdAsync(string id)
        {
            ApplicationUser user = await _userRepository.FindByIdAsync(id);
            UserModelItem model = new UserModelItem { Email = user.Email, Id = user.Id, FirstName = user.FirstName, LastName = user.LastName };
            return model;
        }

        public async Task<UserModelItem> FindByEmailAsync(string email)
        {
            ApplicationUser user = await _userRepository.FindByEmailAsync(email);
            UserModelItem model = new UserModelItem { Email = user.Email, Id = user.Id, FirstName = user.FirstName, LastName = user.LastName };
            return model;
    }

        public async Task<IdentityResult> UpdateAsync(UserModelItem userModel)
        {
            ApplicationUser user = await _userRepository.FindByEmailAsync(userModel.Email);
            return await _userRepository.UpdateAsync(user);
        }

        public List<UserModelItem> GetUsersAsync()
        {
            List<ApplicationUser> users = _userRepository.GetUsersAsync();
            List<UserModelItem> models  = users.Select(user => new UserModelItem 
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
            ApplicationUser user = await _userRepository.FindByEmailAsync(userModel.Email);
            return await _userRepository.AddToRoleAsync(user, role);
        }

        public async Task<IList<string>> GetRolesAsync(UserModelItem userModel)
        {
            ApplicationUser user = await _userRepository.FindByEmailAsync(userModel.Email);
            return await _userRepository.GetRolesAsync(user);
        }

        public async Task<bool> IsInRoleAsync(UserModelItem userModel, string role)
        {
            ApplicationUser user = await _userRepository.FindByEmailAsync(userModel.Email);
            return await _userRepository.IsInRoleAsync(user, role);
        }

        public async Task<IdentityResult> RemoveFromRoleAsync(UserModelItem userModel, string role)
        {
            ApplicationUser user = await _userRepository.FindByEmailAsync(userModel.Email);
            return await _userRepository.RemoveFromRoleAsync(user, role);
        }

        public async Task<bool> IsEmailConfirmedAsync(LoginViewModel loginViewModel)
        {
            ApplicationUser user = await _userRepository.FindByEmailAsync(loginViewModel.Email);
            return await _userRepository.IsEmailConfirmedAsync(user);
        }

        public async Task<SignInResult> PasswordSignInAsync(string id, string password, bool isPersistent)
        {
            ApplicationUser user = await _userRepository.FindByIdAsync(id);
            return await _userRepository.PasswordSignInAsync(user, password, isPersistent);
        }

        public async Task SignOutAsync()
        {
             await _userRepository.SignOutAsync();
        }
    }
}

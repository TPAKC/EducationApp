using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
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

        public async Task<IdentityResult> Create(UserModel userModel)
        {
            ApplicationUser user = await _userRepository.FindByEmail(userModel.Email);
            user = new ApplicationUser { Email = userModel.Email, UserName = userModel.Email };
            var result = await _userRepository.Create(user, userModel.Password);
            return await _userRepository.AddToRole(user, userModel.Role);
        }

        public virtual async Task<IdentityResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel, string password)
        {
            //handle the exception
            ApplicationUser user = await _userRepository.FindByEmail(changePasswordViewModel.Email);
            return await _userRepository.ChangePassword(user, password, changePasswordViewModel.NewPassword); //you may need to enter the password manually
        }

        public virtual async Task<IdentityResult> Delete(UserModel userModel)
        {
            ApplicationUser user = await _userRepository.FindByEmail(userModel.Email);
            return await _userRepository.Delete(user); 
        }

        public virtual async Task<UserModel> FindById(string id)
        {
            ApplicationUser user = await _userRepository.FindById(id);
            UserModel model = new UserModel { Email = user.Email, Id = user.Id, FirstName = user.FirstName, LastName = user.LastName };
            return model;
        }

        public virtual async Task<UserModel> FindByEmail(string email)
        {
            ApplicationUser user = await _userRepository.FindByEmail(email);
            UserModel model = new UserModel { Email = user.Email, Id = user.Id, FirstName = user.FirstName, LastName = user.LastName };
            return model;
    }

        public virtual async Task<IdentityResult> Update(UserModel userModel)
        {
            ApplicationUser user = await _userRepository.FindByEmail(userModel.Email);
            return await _userRepository.Update(user);
        }

        public virtual List<UserModel> GetUsers()
        {
            List<ApplicationUser> users = _userRepository.GetUsers();
            List<UserModel> models = new List<UserModel>();
            foreach (ApplicationUser user in users)
            {
                UserModel model = new UserModel { Email = user.Email, Id = user.Id, FirstName = user.FirstName, LastName = user.LastName};
                models.Add(model);
            }
            return models;
        }

        public virtual async Task<IdentityResult> AddToRole(UserModel userModel, string role)
        {
            ApplicationUser user = await _userRepository.FindByEmail(userModel.Email);
            return await _userRepository.AddToRole(user, role);
        }

        public virtual async Task<IList<string>> GetRoles(UserModel userModel)
        {
            ApplicationUser user = await _userRepository.FindByEmail(userModel.Email);
            return await _userRepository.GetRoles(user);
        }

        public virtual async Task<bool> IsInRole(UserModel userModel, string role)
        {
            ApplicationUser user = await _userRepository.FindByEmail(userModel.Email);
            return await _userRepository.IsInRole(user, role);
        }

        public virtual async Task<IdentityResult> RemoveFromRole(UserModel userModel, string role)
        {
            ApplicationUser user = await _userRepository.FindByEmail(userModel.Email);
            return await _userRepository.RemoveFromRole(user, role);
        }

        public virtual async Task<bool> IsEmailConfirmed(LoginViewModel loginViewModel)
        {
            ApplicationUser user = await _userRepository.FindByEmail(loginViewModel.Email);
            return await _userRepository.IsEmailConfirmed(user);
        }
    }
}

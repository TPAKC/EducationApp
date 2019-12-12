using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.DapperRepositories
{

    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> ChangePasswordAsync(ApplicationUser user, string oldPassword, string newPassword)
        {
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return result.Succeeded;
        }

        public async Task<bool> CreateAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }
        public async Task<bool> DeleteAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<ApplicationUser> FindByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> UpdateAsync(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public List<ApplicationUser> GetUsersAsync()
        {
           List<ApplicationUser> result = new List<ApplicationUser>();
          // var users = _userManager.Users.ToList();
         /*   var evens = users.Where(user => !user.IsRemoved);
            foreach (ApplicationUser user in evens) result.Add(user);*/
                return result; //todo filter list+
        }

        public async Task<bool> AddToRoleAsync(ApplicationUser user, string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<bool> IsInRoleAsync(ApplicationUser user, string role)
        {
            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<bool> RemoveFromRoleAsync(ApplicationUser user, string role)
        {
            var result = await _userManager.RemoveFromRoleAsync(user, role);
            return result.Succeeded;
        }

        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<bool> IsEmailConfirmedAsync(ApplicationUser user)
        {
            return await _userManager.IsEmailConfirmedAsync(user);  
        }

        public async Task<bool> PasswordSignInAsync(ApplicationUser user, string password, bool isPersistent)
        {
            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent, false);
            return result.Succeeded;
        }

        public async Task SignOutAsync()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<bool> ConfirmEmailAsync(ApplicationUser user, string code)
        {
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return result.Succeeded;
        }

        public async Task<bool> ResetPasswordAsync(ApplicationUser user, string code, string password)
        {
            var result = await _userManager.ResetPasswordAsync(user, code, password);
            return result.Succeeded;
        }
    }
}
   
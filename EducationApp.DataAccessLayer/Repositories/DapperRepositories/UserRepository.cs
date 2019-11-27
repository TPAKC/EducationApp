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

        public virtual async Task<IdentityResult> ChangePassword(ApplicationUser user, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public virtual async Task<IdentityResult> Create(ApplicationUser user)
        {
            return await _userManager.CreateAsync(user);
        }
        public virtual async Task<IdentityResult> Create(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        public virtual async Task<IdentityResult> Delete(ApplicationUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public virtual async Task<ApplicationUser> FindById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public virtual async Task<ApplicationUser> FindByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public virtual async Task<IdentityResult> Update(ApplicationUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public virtual List<ApplicationUser> GetUsers()
        {
            return _userManager.Users.ToList();
        }

        public virtual async Task<IdentityResult> AddToRole(ApplicationUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public virtual async Task<IList<string>> GetRoles(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public virtual async Task<bool> IsInRole(ApplicationUser user, string role)
        {
            return await _userManager.IsInRoleAsync(user,role);
        }

        public virtual async Task<IdentityResult> RemoveFromRole(ApplicationUser user, string role)
        {
            return await _userManager.RemoveFromRoleAsync(user, role);
        }
    }
}

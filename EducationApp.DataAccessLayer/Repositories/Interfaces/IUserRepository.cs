using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string oldPassword, string newPassword);
        Task<IdentityResult> CreateAsync(ApplicationUser user);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> DeleteAsync(ApplicationUser user);
        Task<ApplicationUser> FindByIdAsync(string id);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<IdentityResult> UpdateAsync(ApplicationUser user);
        List<ApplicationUser> GetUsersAsync();
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<bool> IsInRoleAsync(ApplicationUser user, string role);
        Task<IdentityResult> RemoveFromRoleAsync(ApplicationUser user, string role);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<bool> IsEmailConfirmedAsync(ApplicationUser user);
        Task<SignInResult> PasswordSignInAsync(ApplicationUser user, string password, bool isPersistent);
        Task SignOutAsync();
    }
}

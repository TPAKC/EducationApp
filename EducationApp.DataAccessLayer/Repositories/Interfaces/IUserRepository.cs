using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> ChangePassword(ApplicationUser user, string oldPassword, string newPassword);
        Task<IdentityResult> Create(ApplicationUser user);
        Task<IdentityResult> Create(ApplicationUser user, string password);
        Task<IdentityResult> Delete(ApplicationUser user);
        Task<ApplicationUser> FindById(string id);
        Task<ApplicationUser> FindByEmail(string email);
        Task<IdentityResult> Update(ApplicationUser user);
        List<ApplicationUser> GetUsers();
        Task<IdentityResult> AddToRole(ApplicationUser user, string role);
        Task<IList<string>> GetRoles(ApplicationUser user);
        Task<bool> IsInRole(ApplicationUser user, string role);
        Task<IdentityResult> RemoveFromRole(ApplicationUser user, string role);
        Task<string> GeneratePasswordResetToken(ApplicationUser user);
        Task<bool> IsEmailConfirmed(ApplicationUser user);
    }
}

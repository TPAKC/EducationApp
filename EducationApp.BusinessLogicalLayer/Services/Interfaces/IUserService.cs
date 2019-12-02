using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateAsync(UserModelItem userModel);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel);
        Task<IdentityResult> DeleteAsync(string id);
        Task<UserModelItem> FindByIdAsync(string id);
        Task<UserModelItem> FindByEmailAsync(string email);
        Task<IdentityResult> UpdateAsync(UserModelItem userModel);
        List<UserModelItem> GetUsersAsync();
        Task<IdentityResult> AddToRoleAsync(UserModelItem userModel, string role);
        Task<IList<string>> GetRolesAsync(UserModelItem userModel);
        Task<bool> IsInRoleAsync(UserModelItem userModel, string role);
        Task<IdentityResult> RemoveFromRoleAsync(UserModelItem userModel, string role);
        Task<bool> IsEmailConfirmedAsync(LoginViewModel loginViewModel);
        Task<SignInResult> PasswordSignInAsync(string id, string password, bool isPersistent);
        Task SignOutAsync();
    }
}

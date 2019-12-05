using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModelItem> CreateAsync(CreateUserViewModel user, RegisterViewModel userModel);
        Task<BaseModel> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel);
        Task<BaseModel> DeleteAsync(string id);
        Task<UserModelItem> FindByIdAsync(string id);
        Task<UserModelItem> FindByEmailAsync(string email);
        Task<BaseModel> UpdateAsync(UserModelItem userModel);
        List<UserModelItem> GetUsersAsync();
        Task<BaseModel> AddToRoleAsync(UserModelItem userModel, string role);
        Task<IList<string>> GetRolesAsync(UserModelItem userModel);
        Task<bool> IsInRoleAsync(UserModelItem userModel, string role);
        Task<BaseModel> RemoveFromRoleAsync(UserModelItem userModel, string role);
        Task<bool> IsEmailConfirmedAsync(UserModelItem userModel);
        Task<SignInResult> PasswordSignInAsync(string id, string password, bool isPersistent);
        Task<SignInResult> SignOutAsync();
        Task<string> GenerateEmailConfirmationTokenAsync(string email);
        Task<BaseModel> ConfirmEmailAsync(string id, string code);
        Task<BaseModel> ResetPasswordAsync(string email, string code, string password);
    }
}

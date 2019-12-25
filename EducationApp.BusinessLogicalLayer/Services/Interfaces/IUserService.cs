using EducationApp.BusinessLogicalLayer.Models;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModelItem> CreateAsync(CreateModel registerModel);
        Task<BaseModel> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel);
        Task<BaseModel> DeleteAsync(string id);
        Task<UserModelItem> FindByIdAsync(string id);
        Task<UserModelItem> FindByEmailAsync(string email);
        Task<BaseModel> UpdateAsync(UserModelItem userModel);
        UserModel GetUsersAsync(bool isActive, bool isBlocked, int numberSortState);
        Task<BaseModel> AddToRoleAsync(UserModelItem userModel, string role);
        Task<BaseModel> RemoveFromRoleAsync(UserModelItem userModel, string role);
        Task<bool> IsEmailConfirmedAsync(string email);
        Task SignOutAsync();
        Task<string> GenerateEmailConfirmationTokenAsync(string email);
        Task<BaseModel> ConfirmEmailAsync(string id, string code);
        Task<BaseModel> ResetPasswordAsync(string email, string code, string password);
        Task<BaseModel> ForgotPassword(string email);
        Task<LoginView> Login(string email, string password, bool rememberMe);
        Task<BaseModel> ChangeUserStatus(string id, bool userStatus);
    }
}

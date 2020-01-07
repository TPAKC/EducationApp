using EducationApp.BusinessLogicalLayer.Models;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Models.Account;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModelItem> CreateAsync(CreateUserModel registerModel);
        Task<BaseModel> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel);
        Task<BaseModel> DeleteAsync(long id);
        Task<BaseModel> UpdateAsync(UserModelItem userModel);
        UserModel GetUsersAsync(bool isActive, bool isBlocked, int numberSortState);
        Task SignOutAsync();
        Task<string> GenerateEmailConfirmationTokenAsync(string email);
        Task<BaseModel> ConfirmEmailAsync(long id, string code);
        Task<BaseModel> ForgotPassword(string email);
        Task<LoginView> Login(string email, string password, bool rememberMe);
        Task<BaseModel> ChangeUserStatus(long id, bool userStatus);
    }
}

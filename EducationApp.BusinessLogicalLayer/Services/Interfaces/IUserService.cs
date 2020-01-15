using EducationApp.BusinessLogicalLayer.Models;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Models.Account;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModelItem> CreateAsync(RegistrationModel registerModel);
        Task<BaseModel> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel);
        Task<BaseModel> DeleteAsync(long id);
        Task<BaseModel> UpdateAsync(UserModelItem userModel);
        UserModel GetAllAsync(bool isActive, bool isBlocked, int numberSortState);
        Task LogOutAsync();
        Task<string> GenerateEmailConfirmationTokenAsync(string email);
        Task<BaseModel> ConfirmEmailAsync(long id, string code);
        Task<BaseModel> ForgotPasswordAsync(string email);
        Task<LoginModel> LoginAsync(string email, string password, bool rememberMe);
        Task<BaseModel> ChangeStatusAsync(long id, bool userStatus);
    }
}

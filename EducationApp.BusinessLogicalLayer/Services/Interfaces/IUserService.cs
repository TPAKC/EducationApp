using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Create(UserModel userModel);
        Task<IdentityResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel, string password);
        Task<IdentityResult> Delete(UserModel userModel);
        Task<UserModel> FindById(string id);
        Task<UserModel> FindByEmail(string email);
        Task<IdentityResult> Update(UserModel userModel);
        List<UserModel> GetUsers();
        Task<IdentityResult> AddToRole(UserModel userModel, string role);
        Task<IList<string>> GetRoles(UserModel userModel);
        Task<bool> IsInRole(UserModel userModel, string role);
        Task<IdentityResult> RemoveFromRole(UserModel userModel, string role);
        Task<bool> IsEmailConfirmed(LoginViewModel loginViewModel);

    }
}

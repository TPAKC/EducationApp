﻿using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.RequestModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ChangePasswordAsync(ApplicationUser user, string oldPassword, string newPassword);
        Task<bool> CreateAsync(ApplicationUser user, string password);
        Task<ApplicationUser> FindByIdAsync(long id);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<bool> UpdateAsync(ApplicationUser user);
        Task<List<ApplicationUser>> FilteredAsync(PaginationModel sortState);
        Task<bool> AddToRoleAsync(ApplicationUser user, string role);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<bool> IsInRoleAsync(ApplicationUser user, string role);
        Task<bool> RemoveFromRoleAsync(ApplicationUser user, string role);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<bool> IsEmailConfirmedAsync(ApplicationUser user);
        Task<bool> PasswordSignInAsync(ApplicationUser user, string password, bool isPersistent);
        Task LogOutAsync();
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<bool> ConfirmEmailAsync(ApplicationUser user, string code);
        Task<bool> ResetPasswordAsync(ApplicationUser user, string password);
    }
}

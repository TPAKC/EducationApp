using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper
    {
        private readonly IUserRepository _userRepository;

        public Mapper(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApplicationUser> UserModelITemToApplicationUser(UserModelItem userModel)
        {
            var user = await _userRepository.FindByIdAsync(userModel.Id);
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            var code = await _userRepository.GeneratePasswordResetTokenAsync(user);
            if (!String.IsNullOrWhiteSpace(userModel.Pasword)) await _userRepository.ResetPasswordAsync(user, code, userModel.Pasword);
            return user;
        }
    }
}

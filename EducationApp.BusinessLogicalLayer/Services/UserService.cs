using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Services
{
    class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IdentityResult> Create(UserModel userModel)
        {
            ApplicationUser user = await _userRepository.FindByEmail(userModel.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userModel.Email, UserName = userModel.Email };
                var result = await _userRepository.Create(user, userModel.Password);
                return await _userRepository.AddToRole(user, userModel.Role);
            }//add else variant ("error")
            else
            {
                return null;
            }
        }

    }
}

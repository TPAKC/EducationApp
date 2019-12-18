using EducationApp.BusinessLogicalLayer.Models;
using EducationApp.BusinessLogicalLayer.Models.Authors;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public class Mapper
    {
        private readonly IUserRepository _userRepository;

        public Mapper(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModelItem ApplicationUserToUserModelITem(ApplicationUser user)
        {
            var model = new UserModelItem
            {
                Email = user.Email,
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return model;
        }

        public ApplicationUser RegisterModelToApplicationUser(CreateModel registerModel)
        {
            var user = new ApplicationUser
            {
                Email = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                UserName = Guid.NewGuid().ToString()
            };
            return user;
        }

        public AuthorModelItem AuthorToAuthorModelItem(Author author)
        {
            var authorModel = new AuthorModelItem
            {
                Name = author.Name
            };
            return authorModel;
        }

        public async Task<ApplicationUser> UserModelITemToApplicationUser(UserModelItem userModel)
        {
            var user = await _userRepository.FindByIdAsync(userModel.Id);
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            if(!String.IsNullOrWhiteSpace(userModel.Pasword)) _userRepository.
            return user;
        }

        //public PrintingEditionItem PrintingEditionModelToPrintingEditionItem()
        //{

        //}
    }
}

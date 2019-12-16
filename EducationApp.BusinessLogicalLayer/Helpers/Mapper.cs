using EducationApp.BusinessLogicalLayer.Models;
using EducationApp.BusinessLogicalLayer.Models.Authors;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public class Mapper
    {
        public UserModelItem ApplicationUserToUserModelITem(ApplicationUser user)
        {
            var model = new UserModelItem();
            model.Email = user.Email;
            model.Id = user.Id;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            return model;
        }

        public ApplicationUser RegisterModelToApplicationUser(CreateModel registerModel)
        {
            var user = new ApplicationUser();
            user.Email = registerModel.Email;
            user.FirstName = registerModel.FirstName;
            user.LastName = registerModel.LastName;
            return user;
        }

        public AuthorModelItem AuthorToAuthorModelItem(Author author)
        {
            var authorModel = new AuthorModelItem();
            authorModel.Name = author.Name;
            return authorModel;
        }
    }
}

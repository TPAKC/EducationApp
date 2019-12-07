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
    }
}

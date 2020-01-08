using EducationApp.BusinessLogicalLayer.Models.Models.Account;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper
    {
        public ApplicationUser RegisterModelToApplicationUser(CreateUserModel registerModel)
        {
            var user = new ApplicationUser
            {
                Email = registerModel.Email,
                UserName = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName
            };
            return user;
        }
    }
}

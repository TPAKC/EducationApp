using EducationApp.BusinessLogicalLayer.Helpers.Mapper.Interface;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Helpers.Mapper
{
    public partial class Mapper : IMapper
    {
        public ApplicationUser ModelItemToEntity(UserModelItem userModel)
        {
            var user = new ApplicationUser();
            user.Id = userModel.Id;
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            return user;
        }
    }
}

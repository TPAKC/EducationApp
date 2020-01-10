using EducationApp.BusinessLogicalLayer.Helpers.Mapper.Interface;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicalLayer.Helpers.Mapper
{
    public partial class Mapper : IMapper
    {
        public UserModelItem EntityToModelITem(ApplicationUser user)
        {
            var modelItem = new UserModelItem();
            modelItem.Email = user.Email;
            modelItem.Id = user.Id;
            modelItem.FirstName = user.FirstName;
            modelItem.LastName = user.LastName;
            return modelItem;
        }
    }
}

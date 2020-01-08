using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.DataAccessLayer.Entities;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
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
}

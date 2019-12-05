using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.User
{
    public class UserModel : BaseModel
    {
        public List<UserModelItem> Users = new List<UserModelItem>();
    }
    public class UserModelItem : BaseModel
    {
        [Required]
        public string Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }

}

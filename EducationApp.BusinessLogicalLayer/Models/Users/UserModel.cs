using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.Users
{
    public class UserModel : BaseModel
    {
        public List<UserModelItem> Users = new List<UserModelItem>();
    }
    public class UserModelItem : BaseModel
    {
        [Required]
        public long Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
    }

}

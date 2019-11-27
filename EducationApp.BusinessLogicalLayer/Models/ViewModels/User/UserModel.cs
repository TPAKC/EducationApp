using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels.User
{
    public class UserModel
    {
        public long Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationApp.BusinessLogicalLayer.Models.Models.Account
{
    public class CreateUserModel: BaseCreateUpdateUserModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

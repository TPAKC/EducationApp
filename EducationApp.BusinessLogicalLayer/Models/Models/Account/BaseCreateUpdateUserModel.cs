using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationApp.BusinessLogicalLayer.Models.Models.Account
{
    public class BaseCreateUpdateUserModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}

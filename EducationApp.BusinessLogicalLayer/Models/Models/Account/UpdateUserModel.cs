using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EducationApp.BusinessLogicalLayer.Models.Models.Account
{
    public class UpdateUserModel: BaseCreateUpdateUserModel
    {
        [Required]
        public string Id { get; set; }
    }
}

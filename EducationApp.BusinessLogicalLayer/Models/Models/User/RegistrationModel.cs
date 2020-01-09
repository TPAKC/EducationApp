using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.Models.Account
{
    public class RegistrationModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}

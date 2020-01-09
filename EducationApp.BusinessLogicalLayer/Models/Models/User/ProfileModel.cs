using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.Models.Account
{
    public class ProfileModel
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}

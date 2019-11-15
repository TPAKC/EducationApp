using System.ComponentModel.DataAnnotations;

namespace EducationApp.BusinessLogicalLayer.Models.ViewModels
{
        public class RegisterViewModel
        {

            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "LastName")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required]
            [Compare("Password", ErrorMessage = "Passwords do not match")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm the password")]
            public string PasswordConfirm { get; set; }
        }
}

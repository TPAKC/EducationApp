using Microsoft.AspNetCore.Identity;
using System;

namespace EducationApp.DataAccessLayer.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsRemoved { get; set; } = false;
        public bool IsBlocked { get; set; } = false;
        public DateTime CreatingDate { get; set; } = DateTime.Now;
    }
}

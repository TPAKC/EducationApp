using EducationApp.DataAccessLayer.Entities;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Helpers.Interfaces
{
    public interface IJwtHelper
    {
        Task<string> GenerateEncodedToken(ApplicationUser user, string userRole);
        ClaimsIdentity GenerateClaimsIdentity(ApplicationUser user, string role);
        long ToUnixEpochDate(DateTime date);
    }
}

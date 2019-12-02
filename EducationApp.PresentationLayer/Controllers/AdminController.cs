using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EducationApp.PresentationLayer.Controllers
{
    public class AdminController : ControllerBase
    {
        IUserService _userService;
        public AdminController(IUserService serv)
        {
            _userService = serv;
        }
       /* public IActionResult Index()
        {
            return Ok(_userService.Users.ToList());
        }
        public IActionResult GetRoles()
        {
            return Ok(_userService.Roles.ToList());
        }*/
    }
}
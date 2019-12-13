using EducationApp.BusinessLogicalLayer.Models;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomIdentityApp.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(UserModelItem user)
        {
            var result = await _userService.UpdateAsync(user);
            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var result = await _userService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("changePassword")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            var result = await _userService.ChangePasswordAsync(model);
            return Ok(result);
        }

        [HttpGet("changeUserStatus")]
        public async Task<IActionResult> ChangeUserStatus(string id, bool userStatus)
        {
            var result = await ChangeUserStatus(id, userStatus);
            return Ok(result);
        }
    }
}
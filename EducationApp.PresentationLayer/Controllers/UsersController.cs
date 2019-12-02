using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomIdentityApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;
        public UsersController(IUserService serv)
        {
            _userService = serv;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(UserModelItem user) {
            await _userService.CreateAsync(user);
           return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UserModelItem user)
        {
            await _userService.UpdateAsync(user);
            return Ok();
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(string id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            return Ok(await _userService.ChangePasswordAsync(model));
        }
    }
}
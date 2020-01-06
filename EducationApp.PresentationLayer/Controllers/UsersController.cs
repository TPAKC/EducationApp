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

        [HttpGet("users")]
        public ActionResult UsersAsync(bool isActive, bool isBlocked, int numberSortState)
        {
            var result = _userService.GetUsersAsync(isActive, isBlocked, numberSortState);
            if(result.Errors.Count!=0) return Ok(result.Errors);
            return Ok(result.Users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(UserModelItem userModel)
        {
            var result = await _userService.UpdateAsync(userModel);
            return Ok(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        { 
            var result = await _userService.DeleteAsync(id);
            return Ok(result.Errors);
        }

        [HttpGet("changeUserStatus")]
        public async Task<IActionResult> ChangeUserStatus(string id, bool userStatus)
        {
            var result = await _userService.ChangeUserStatus(id, userStatus);
            return Ok(result.Errors);
        }
    }
}
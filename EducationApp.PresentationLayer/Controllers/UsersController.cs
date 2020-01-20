using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomIdentityApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public ActionResult GetAll(bool isActive, bool isBlocked, int numberSortState)//в filter Model запаковать
        {
            var result = _userService.GetSortedAsync();
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(UserModelItem userModel)
        {
            var result = await _userService.UpdateAsync(userModel);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(long id)
        { 
            var result = await _userService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("changeUserStatus/{id}")]
        public async Task<IActionResult> ChangeUserStatus(long id, bool userStatus)
        {
            var result = await _userService.ChangeStatusAsync(id, userStatus);
            return Ok(result);
        }
    }
}
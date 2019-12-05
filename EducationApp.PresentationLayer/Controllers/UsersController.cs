using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
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

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateUserViewModel user) //todo use RegistrModel
        { 
           var result = await _userService.CreateAsync(user); //todo get response
           return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UserModelItem user)
        {
            var result = await _userService.UpdateAsync(user);
            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _userService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var result = await _userService.ChangePasswordAsync(model);
            return Ok(result);
        }
    }
}
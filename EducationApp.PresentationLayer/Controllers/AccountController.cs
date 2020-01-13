using EducationApp.BusinessLogicalLayer.Helpers.Interfaces;
using EducationApp.BusinessLogicalLayer.Models.Models.Account;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.PresentationLayer.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static EducationApp.PresentationLayer.Common.Constants.TemplateText;

namespace EducationApp.PresentationLayer.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IEmailHelper _emailHelper; // в BLL 
        private readonly IJwtHelper _jwtHelper;

        public AccountController(IUserService userService, IEmailHelper emailHelper, IJwtHelper jwtHelper)
        {
            _userService = userService;
            _emailHelper = emailHelper;
            _jwtHelper = jwtHelper;
        }

        [Authorize]
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            var resultModel = await _userService.Login(email,password,rememberMe);
            return Ok(resultModel);
        }

        [Authorize]
        [HttpPost("logOut")]
        public async Task<IActionResult> LogOut()
        {
            var resultModel =  await _userService.LogOutAsync();
            return Ok(resultModel);
        }

        [Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationModel createModel)
        {
            var resultModel = await _userService.CreateAsync(createModel);
            var code = await _userService.GenerateEmailConfirmationTokenAsync(createModel.Email);
            var callbackUrl = Url.Action(
                "ConfirmEmail", //в константу   +  все константы в BLL
                "Account", // в константу
                new { userId = resultModel.Id, code },
                protocol: HttpContext.Request.Scheme);
                await _emailHelper.SendEmailAsync(createModel.Email, // доставать с _userService а не с  _emailHelper
                    "Confirm your account", $"{ConfirmTheRegistration}<a href='{callbackUrl}'>link</a>");
            return Ok(resultModel);
            }

        [Authorize]
        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(long userId, string code)
        {
            var result = await _userService.ConfirmEmailAsync(userId, code);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPasswordForEmail(string email)
        {
            var result = await _userService.ForgotPassword(email);
            return Ok(result);
        }
    }
}
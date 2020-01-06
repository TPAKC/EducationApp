using EducationApp.BusinessLogicalLayer.Helpers;
using EducationApp.BusinessLogicalLayer.Models.Models.Account;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static EducationApp.PresentationLayer.Common.Constants.TemplateText;

namespace EducationApp.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly EmailHelper _emailHelper;

        public AccountController(IUserService service, EmailHelper emailHelper)
        {
            _emailHelper = emailHelper;
            _userService = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            var resultModel = await _userService.Login(email,password,rememberMe);
            return Ok(resultModel.Errors);
        }
           
        [HttpPost("logOut")]
        public async Task<IActionResult> LogOut() //todo LogOut +
        {
            await _userService.SignOutAsync();
            return Ok(); //todo return Ok(); +
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserModel createModel)
        {
            var resultModel = await _userService.CreateAsync(createModel);
            var code = await _userService.GenerateEmailConfirmationTokenAsync(createModel.Email);
            var callbackUrl = Url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = resultModel.Id, code },
                protocol: HttpContext.Request.Scheme);
                await _emailHelper.SendEmailAsync(createModel.Email,
                    "Confirm your account", $"{ConfirmTheRegistration}<a href='{callbackUrl}'>link</a>");
            return Ok(resultModel.Errors);
            }  

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            var result = await _userService.ConfirmEmailAsync(userId, code);
            return Ok(result.Errors);
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPasswordForEmail(string email)
        {
            var result = await _userService.ForgotPassword(email);
            return Ok(result.Errors);
        }
    }
}
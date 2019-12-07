using EducationApp.BusinessLogicalLayer.Helpers;
using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Models.ViewModels.User;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Collections.Generic;

namespace EducationApp.PresentationLayer.Controllers
{
    public class AccountController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly EmailHelper _emailHelper;
        public AccountController(IUserService service, EmailHelper emailHelper)
        {
            _userService = service;
            _emailHelper = emailHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

                var result = await _userService.IsEmailConfirmedAsync(model);
            if (result != null)
            {
                await Authenticate(model.Email);
                    }

            var resultPasswordSignIn = await _userService.PasswordSignInAsync(model.Email, model.Password, model.RememberMe);
                if (resultPasswordSignIn.Succeeded)
                {
                    UserModelItem user = await _userService.FindByEmailAsync(model.Email);
                }
            return Ok(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut() //todo LogOut +
        {
            var result = await _userService.SignOutAsync();
            return Ok(result); //todo return Ok(); +
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
                //var user = await _userService.FindByEmailAsync(model.Email);
                var resultModel = await _userService.CreateAsync(model);
                if (resultModel.Errors.Any())
                {
                    return Ok(resultModel);
                }

                var code = await _userService.GenerateEmailConfirmationTokenAsync(model.Email);
                var callbackUrl = Url.Action(
                    "ConfirmEmail",
                    "Account",
                    new { userId = resultModel.Id, code },
                    protocol: HttpContext.Request.Scheme);
                await _userService.SendEmailAsync(model.Email, "Confirm your account",
                    $"Confirm registration by clicking on the <a href='{callbackUrl}'>link</a>");
                return Ok(resultModel);
            }  

        [HttpGet("confirmEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            var result = await _userService.ConfirmEmailAsync(userId, code);
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.FindByEmailAsync(model.Email);
                if (user == null || !(await _userService.IsEmailConfirmedAsync(user)))
                {
                    return Ok("ForgotPasswordConfirmation");
                }

                var code = await _userService.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code }, protocol: HttpContext.Request.Scheme);
                await _emailHelper.SendEmailAsync(model.Email, "Reset Password",
                    $"To reset your password, follow the <a href='{callbackUrl}'>link</a>");
                return Ok("ForgotPasswordConfirmation");
            }
            return Ok(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return Ok("Error");
            } 
            return Ok();

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(model);
            }
            var result = await _userService.ResetPasswordAsync(model.Email, model.Code, model.Password);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Ok(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
    {
        new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
    };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
﻿using EducationApp.BusinessLogicalLayer.Helpers;
using EducationApp.BusinessLogicalLayer.Models;
using EducationApp.BusinessLogicalLayer.Models.Base;
using EducationApp.BusinessLogicalLayer.Models.Users;
using EducationApp.BusinessLogicalLayer.Models.ViewModels;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static EducationApp.BusinessLogicalLayer.Common.Constants.AccountRole;
using static EducationApp.BusinessLogicalLayer.Common.Constants.ServiceValidationErrors;
using static EducationApp.BusinessLogicalLayer.Common.Constants.TemplateText;

namespace EducationApp.BusinessLogicalLayer.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly Mapper _mapper;
        private readonly JwtHelper _jwtHelper;
        private readonly JwtOptions _jwtOptions;
        private readonly EmailHelper _emailHelper;
        //todo inject IEmailHelper +
        public UserService(IUserRepository userRepository, Mapper mapper, JwtHelper jwtHelper,
                              IOptions<JwtOptions> jwtOptions, EmailHelper emailHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            _jwtOptions = jwtOptions.Value;
            _emailHelper = emailHelper;
        }

        public async Task<LoginView> Login(string email, string password, bool rememberMe)
        {
            LoginView modelResult = new LoginView();
            var user = await _userRepository.FindByEmailAsync(email);
            var isSignIn = await _userRepository.PasswordSignInAsync(user, password, rememberMe);
            if (user == null || !isSignIn)
            {
                modelResult.Errors.Add("");//add error
                return modelResult;
            }

            var result = new LoginView
            {
                UserId = user.Id,
                Confirmed = user.EmailConfirmed,
                Token = (user.EmailConfirmed) ? await GetAccessToken(user) : null
            };

            return modelResult;
        }

        public async Task<UserModelItem> CreateAsync(CreateModel createModel)
        {
            var resultModel = new UserModelItem();
            var user = await _userRepository.FindByEmailAsync(createModel.Email);
            if (user != null&&!user.IsRemoved)
            {
                resultModel.Errors.Add(UserIsExist);
                return resultModel;
            }
            var newUser = _mapper.RegisterModelToApplicationUser(createModel);
            if (user != null && user.IsRemoved)
            {
               // _userRepository.UpdateAsync();
                return resultModel;
            }
                var result = await _userRepository.CreateAsync(newUser, createModel.Password);
            if (!result)
            {
                resultModel.Errors.Add(UserCantBeRegistered);
                return resultModel;
            }

            result = await _userRepository.AddToRoleAsync(newUser, NameUserRole); //todo errors and roles from constants or enums +
            if (!result)
            {
                resultModel.Errors.Add(UserCantBeAddedToRole);
            }
            resultModel.Id = newUser.Id;
            return resultModel;
        }

        public async Task<BaseModel> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel)
        {
            var resultModel = new BaseModel();
            if (changePasswordViewModel == null) 
            {
                resultModel.Errors.Add(ModelIsExist);
                return resultModel;
            }

            var user = await _userRepository.FindByEmailAsync(changePasswordViewModel.Email);
            if (user == null)
            {
                resultModel.Errors.Add(UserIsExist);
                return resultModel;
            }

            var result = await _userRepository.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword); //you may need to enter the password manually
            if (!result)
            {
                resultModel.Errors.Add(FailedToChangePassword);
            }

            return resultModel;
        }

        public async Task<BaseModel> DeleteAsync(string id)
        {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null)
            {
                resultModel.Errors.Add(UserIsExist);
                return resultModel;
            }

            var result = await _userRepository.DeleteAsync(user);
            if (!result)
            {
                resultModel.Errors.Add(FailedToRemoveUser);
            }

            return resultModel;
        }

        public async Task<UserModelItem> FindByIdAsync(string id)
        {
            var userResultModel = new UserModelItem();
            var user = await _userRepository.FindByIdAsync(id);
            if(user == null) //todo check user for null +
            {
                userResultModel.Errors.Add(UserIsExist);
                return userResultModel;
            }
            userResultModel = _mapper.ApplicationUserToUserModelITem(user);
            return userResultModel; //todo map at mappers (Excention) +
        }

    public async Task<UserModelItem> FindByEmailAsync(string email)
    {
            var userResultModel = new UserModelItem();
            var user = await _userRepository.FindByEmailAsync(email);
        if(user == null)
            {
                userResultModel.Errors.Add(UserIsExist);
                return userResultModel;
            }
            userResultModel = _mapper.ApplicationUserToUserModelITem(user); //todo map at mappers +
            return userResultModel;
    }

    public async Task<BaseModel> UpdateAsync(UserModelItem userModel)
    {
            var resultModel = new BaseModel();
            if (userModel == null)
            {
                resultModel.Errors.Add(ModelIsExist);
            }

            ApplicationUser user = await _userRepository.FindByEmailAsync(userModel.Email);
            if (user == null)
            {
                resultModel.Errors.Add(UserIsExist);
                return resultModel;
            }

            var result = await _userRepository.UpdateAsync(user);
            if (!result)
            {
                resultModel.Errors.Add(FailedToUpdateUser);
            }

            return resultModel;
    }

    public UserModel GetUsersAsync(bool isActive, bool isBlocked)
    {
            var usersResultModel = new UserModel();
            var users = _userRepository.GetUsersAsync(isActive, isBlocked);
        if(users == null)
            {
                usersResultModel.Errors.Add(UserListIsEmpty);
                return usersResultModel;
            }

         usersResultModel.Users = users.Select(user => _mapper.ApplicationUserToUserModelITem(user)).ToList();
            return usersResultModel;
        }

    public async Task<BaseModel> AddToRoleAsync(UserModelItem userModel, string role)
    {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByEmailAsync(userModel.Email);
            if (user == null)
            {
                resultModel.Errors.Add(FailedToUpdateUser);
                return resultModel;
            }
            var result = await _userRepository.AddToRoleAsync(user, role);
            if (!result)
            {
                resultModel.Errors.Add(UserCantBeAddedToRole);
            }
            return resultModel;
        }

    public async Task<BaseModel> RemoveFromRoleAsync(UserModelItem userModel, string role)
    {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByEmailAsync(userModel.Email);
         await _userRepository.RemoveFromRoleAsync(user, role);
            return resultModel;
    }

    public async Task<bool> IsEmailConfirmedAsync(string email)
    {
        var user = await _userRepository.FindByEmailAsync(email);
        return await _userRepository.IsEmailConfirmedAsync(user);
    }

    public async Task SignOutAsync()
    {
            await _userRepository.SignOutAsync();
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(string email)
    {
            var user = await _userRepository.FindByEmailAsync(email);
            return await _userRepository.GenerateEmailConfirmationTokenAsync(user);

        }

    public async Task<BaseModel> ConfirmEmailAsync(string id, string code)
    {
        var resultModel = new BaseModel();
        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(code))
        {
            resultModel.Errors.Add(WrongInputData); //todo from const +
            return resultModel;
        }
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null)
        {
            resultModel.Errors.Add(UserNotFound); //todo from const +
            return resultModel;
        }
        var confirmResult = await _userRepository.ConfirmEmailAsync(user, code);
        if (!confirmResult)
        {
            resultModel.Errors.Add(UserNotConfirmed); //todo from const +
        }
        return resultModel;
    }

    public async Task<BaseModel> ResetPasswordAsync(string email, string code, string password)
    {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByEmailAsync(email);
            var result = await _userRepository.ResetPasswordAsync(user, code, password);
            if(!result)
            {
                resultModel.Errors.Add(FailedToResetPassword);
            }
            return resultModel;
    }
    public async Task<BaseModel> ForgotPassword(string email)
    {
            var resultModel = new BaseModel();
            var newPassword = GeneratePassword();
            var user = await _userRepository.FindByEmailAsync(email);
            if(user==null)
            {
                resultModel.Errors.Add(UserWithThisMailNotFound);
                return resultModel;
            }
            var result = await _userRepository.IsEmailConfirmedAsync(user);
            if (!result)
            {
                resultModel.Errors.Add(UserNotConfirmed);
                return resultModel;
            }
            await _emailHelper.SendEmailAsync(email, "Reset Password", $"{ResetPasswordText}{newPassword}");
            var code = await _userRepository.GeneratePasswordResetTokenAsync(user);
            result = await _userRepository.ResetPasswordAsync(user, code, newPassword);
            if (!result)
            {
                resultModel.Errors.Add(FailedToResetPassword);
                return resultModel;
            }
            return resultModel;
        }

        private string GeneratePassword()
        {
            int[] arr = new int[8];
            Random random = new Random();
            string password = "";
            for (int i = 0; i < arr.Length; i++)
            {
                password += random.Next(0, 9);
            }
            return password;
        }

        private async Task<string> GetAccessToken(ApplicationUser user)
        {
            var roles = await _userRepository.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
            var identity = _jwtHelper.GenerateClaimsIdentity(user, role);

            var (token, expiresin) = await GenerateJwt(identity, user.UserName);
            return token;
        }

        private async Task<(string token, int expiresin)> GenerateJwt(ClaimsIdentity identity, string userName)
        {
            var token = await _jwtHelper.GenerateEncodedToken(userName, identity);
            var expiresin = (int)_jwtOptions.ValidFor.TotalSeconds;
            return (token, expiresin);
        }

        public async Task<BaseModel> ChangeUserStatus(string id, bool userStatus)
        {
            var resultModel = new BaseModel();
            var user = await _userRepository.FindByIdAsync(id);
            if(user == null)
            {
                resultModel.Errors.Add(UserNotFound);
                return resultModel;
            }
            _userRepository.ChangeUserStatus(user, userStatus);
            return resultModel;
        } 
    } 
}

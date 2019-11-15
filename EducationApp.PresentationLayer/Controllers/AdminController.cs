﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.PresentationLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.PresentationLayer.Controllers
{
    public class AdminController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<ApplicationUser> manager)
        {
            _userManager = manager;
        }
        public AdminController(RoleManager<IdentityRole> manager)
        {
            _roleManager = manager;
        }
        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }
        public IActionResult GetRoles()
        {
            return View(_roleManager.Roles.ToList());
        }
    }
}
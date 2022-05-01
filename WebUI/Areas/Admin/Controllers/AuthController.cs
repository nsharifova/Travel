﻿using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.admin.ViewModel;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;

        public AuthController(UserManager<MyUser> userManager, SignInManager<MyUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null) return View();
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (!result.Succeeded)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM, string RetypePassword)
        {
            registerVM.PhotoURL = "https://cdn.pixabay.com/photo/2018/08/28/12/41/avatar-3637425_960_720.png";
            registerVM.About = "";

            if (ModelState.IsValid)
            {



                if (registerVM.Password != RetypePassword)
                {
                    ViewBag.Password = "Sifreler ust-uste dusmur.";
                    return View();
                }

                MyUser user = new()
                {
                    UserName = registerVM.Name,
                    Email = registerVM.Email,
                    Name = registerVM.Name,
                    Surname = registerVM.Surname,
                    About = registerVM.About,
                    PhotoURL = registerVM.PhotoURL
                };

                IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    return View(registerVM);
                }

            }
            return View();

        }

    }
}

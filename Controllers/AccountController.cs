using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using msgr.Database;
using msgr.Helpers;
using msgr.Models;
using msgr.Providers;
using msgr.Services;
using msgr.ViewModels;

namespace msgr.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly ICurrentUserProvider currentUserProvider;
        public AccountController(IUserService userService, ICurrentUserProvider currentUserProvider)
        {
            this.userService = userService;
            this.currentUserProvider = currentUserProvider;
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> Login(string username, string password)
        {
            string hash = HashHelper.GenerateHash(password);
            Guid? userId = userService.Check(username, hash);

            if (userId.HasValue)
                await userService.LogIn(userId.Value, HttpContext);
                
            return userId.HasValue ? "Zalogowano!" : "Nie udało się zalogować";
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Register()
        {
            return currentUserProvider.GetCurrentUserId() == null ? View() : View("Index");
        }

        [HttpPost]
        public RedirectToActionResult Register(RegisterUserVM vm)
        {
            Models.User newUser = Models.User.Create(vm.Username, HashHelper.GenerateHash(vm.Password));
            userService.Add(newUser);
            userService.LogIn(newUser.Id, HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}
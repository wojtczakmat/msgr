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
        private readonly IRepository<User> userRepository;
        private readonly ICurrentUserProvider currentUserProvider;
        public AccountController(IRepository<User> userRepository, IUserService userService, ICurrentUserProvider currentUserProvider)
        {
            this.userRepository = userRepository;
            this.userService = userService;
            this.currentUserProvider = currentUserProvider;
        }
        public string Index()
        {
            var id = currentUserProvider.GetCurrentUserId();
            return id.HasValue ? id.Value.ToString() : "none";
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
            {
                var claims = new List<Claim>() {
                    new Claim("sub", userId.Value.ToString())
                };

                var id = new ClaimsIdentity(claims);
                var p = new ClaimsPrincipal(id);

                await HttpContext.Authentication.SignInAsync("Cookies", p);
            }
            return userId.HasValue ? "Zalogowano!" : "Nie udało się zalogować";
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            return RedirectToAction("Home", "Index");
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Register(RegisterUserVM vm)
        {
            Models.User newUser = Models.User.Create(vm.Username, HashHelper.GenerateHash(vm.Password));
            userRepository.Add(newUser);
            return RedirectToAction("Index", "Home");
        }
    }
}
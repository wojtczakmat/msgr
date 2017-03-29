using Microsoft.AspNetCore.Mvc;
using msgr.Database;
using msgr.Helpers;
using msgr.Models;
using msgr.Services;
using msgr.ViewModels;

namespace msgr.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IRepository<User> userRepository;
        public AccountController(IRepository<User> userRepository, IUserService userService)
        {
            this.userRepository = userRepository;
            this.userService = userService;
        }
        public RedirectToActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public string Login(string username, string password)
        {
            string hash = HashHelper.GenerateHash(password);
            bool isLoggedIn = userService.Check(username, hash);
            return isLoggedIn ? "Zalogowano!" : "Nie udało się zalogować";
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
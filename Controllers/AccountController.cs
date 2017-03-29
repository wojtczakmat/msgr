using Microsoft.AspNetCore.Mvc;
using msgr.Database;
using msgr.Helpers;
using msgr.Models;
using msgr.ViewModels;

namespace msgr.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository<User> userRepository;
        public AccountController(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
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
        public ViewResult Login(string username, string password)
        {
            return View();
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
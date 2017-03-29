using Microsoft.AspNetCore.Mvc;

namespace msgr.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
            
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(string username, string password)
        {

            
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace msgr.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
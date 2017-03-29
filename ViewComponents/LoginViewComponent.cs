using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace msgr.ViewComponents
{
    [ViewComponent(Name = "Login")]
    public class LoginViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Login");
        }
    }
}
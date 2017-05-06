using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using msgr.Models;
using msgr.Providers;
using msgr.Services;

namespace msgr.ViewComponents
{
    [ViewComponent(Name = "Login")]
    public class LoginViewComponent : ViewComponent
    {
        ICurrentUserProvider currentUserProvider;
        IUserService userService;

        public LoginViewComponent(ICurrentUserProvider currentUserProvider, IUserService userService)
        {
            this.currentUserProvider = currentUserProvider;
            this.userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUserId = currentUserProvider.GetCurrentUserId();
            if (currentUserId != null)
            {
                User user =  userService.GetUserById(currentUserId.Value);
                return View("LoggedIn", user);
            }
            return View("NotLoggedIn");
        }
    }
}
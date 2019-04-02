using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Navz.UniversitySystem.WebUI.Controllers
{
    [Authorize]
    public class LogoutController : BaseController
    {
        public IActionResult Index()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
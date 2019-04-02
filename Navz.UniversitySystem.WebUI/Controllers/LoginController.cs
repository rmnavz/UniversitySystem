using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Navz.UniversitySystem.Application.Users.Queries.Login;
using Navz.UniversitySystem.WebUI.Filters;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.WebUI.Controllers
{
    [GuestOnly]
    [AllowAnonymous]
    public class LoginController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserQuery query)
        {
            var User = await Mediator.Send(query);

            if(User != null)
            {
                #region Cookie Authentication
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, User.ID.ToString()),
                    new Claim(ClaimTypes.Name, User.FullName),
                    new Claim(ClaimTypes.Email, User.EmailAddress),
                    new Claim(ClaimTypes.Role, User.UserType.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                #endregion

                return RedirectToAction("Index", "Home");
            }

            return View("Index", query);
        }
    }
}
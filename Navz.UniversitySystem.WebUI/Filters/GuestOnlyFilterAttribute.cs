using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Navz.UniversitySystem.WebUI.Filters
{
    public class GuestOnly : Attribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Redirect("/");
            }
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Navz.UniversitySystem.Application.Infrastructure;
using Navz.UniversitySystem.Common.Enums;
using Navz.UniversitySystem.WebUI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Navz.UniversitySystem.WebUI.Controllers
{
    public class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        private IEnumerable<CardMenu> CardMenuList()
        {
            return new List<CardMenu>()
            {
                new CardMenu(
                    "Administrators",
                    "Administrator Management",
                    "Administrator",
                    "Index",
                    new List<UserType>()
                    {
                        UserType.Administrator
                    }
                ),
                new CardMenu(
                    "Departments",
                    "Department Management",
                    "Department",
                    "Index",
                    new List<UserType>()
                    {
                        UserType.Administrator
                    }
                ),
                new CardMenu(
                    "Subjects",
                    "Subject Management",
                    "Subject",
                    "Index",
                    new List<UserType>()
                    {
                        UserType.Administrator
                    }
                ),
            };

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewData["actionName"] = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            ViewData["controllerName"] = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName;

            if (User.Identity.IsAuthenticated)
            {
                ViewData["CardMenuList"] = CardMenuList()
                .Where(x =>
                    x.UserTypes.Contains(Enum.Parse<UserType>(User.Claims.Where(u => u.Type == ClaimTypes.Role).FirstOrDefault().Value))
                );

                RequestCaller.ID = int.Parse(User.Claims.Where(u => u.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            }
            else
            {
                RequestCaller.ID = 0;
            }

            base.OnActionExecuting(context);
        }
    }
}
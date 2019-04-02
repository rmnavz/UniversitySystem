using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Navz.UniversitySystem.Application.Administrators.Commands.CreateAdministrator;
using Navz.UniversitySystem.Application.Administrators.Commands.DeleteAdministrator;
using Navz.UniversitySystem.Application.Administrators.Commands.UpdateAdministrator;
using Navz.UniversitySystem.Application.Administrators.Queries.GetAdministrator;
using Navz.UniversitySystem.Application.Administrators.Queries.GetAdministratorList;
using Navz.UniversitySystem.Application.Administrators.Queries.GetUpdateAdministrator;
using Navz.UniversitySystem.Application.Hubs;

namespace Navz.UniversitySystem.WebUI.Controllers
{
    [Authorize]
    public class AdministratorController : BaseController
    {
        public IActionResult Index() => View();

        public async Task<IActionResult> Get() => Json(await Mediator.Send(new GetAdministratorListQuery()));

        public async Task<IActionResult> Detail(int ID) => View(await Mediator.Send(new GetAdministratorQuery { ID = ID }));

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdministratorCommand command) => Json(await Mediator.Send(command));

        public async Task<IActionResult> Edit(int ID) => View(await Mediator.Send(new UpdateAdministratorQuery { ID = ID }));

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateAdministratorCommand command) => Json(await Mediator.Send(command));

        public async Task<IActionResult> Delete(int ID) => Json(await Mediator.Send(new DeleteAdministratorCommand { ID = ID }));
    }
}
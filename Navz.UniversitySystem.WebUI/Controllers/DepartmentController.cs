using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Navz.UniversitySystem.Application.Departments.Commands.CreateDepartment;
using Navz.UniversitySystem.Application.Departments.Commands.DeleteDepartment;
using Navz.UniversitySystem.Application.Departments.Commands.UpdateDepartment;
using Navz.UniversitySystem.Application.Departments.Queries.GetDepartment;
using Navz.UniversitySystem.Application.Departments.Queries.GetDepartmentList;
using Navz.UniversitySystem.Application.Departments.Queries.GetUpdateDepartment;

namespace Navz.UniversitySystem.WebUI.Controllers
{
    public class DepartmentController : BaseController
    {
        public IActionResult Index() => View();

        public async Task<IActionResult> Get() => Json(await Mediator.Send(new GetDepartmentListQuery()));

        public async Task<IActionResult> Detail(int ID) => View(await Mediator.Send(new GetDepartmentQuery { ID = ID }));

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentCommand command) => Json(await Mediator.Send(command));

        public async Task<IActionResult> Edit(int ID) => View(await Mediator.Send(new UpdateDepartmentQuery { ID = ID }));

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateDepartmentCommand command) => Json(await Mediator.Send(command));

        public async Task<IActionResult> Delete(int ID) => Json(await Mediator.Send(new DeleteDepartmentCommand { ID = ID }));
    }
}
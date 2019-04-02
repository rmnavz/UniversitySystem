using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Navz.UniversitySystem.Application.Subjects.Commands.CreateSubject;
using Navz.UniversitySystem.Application.Subjects.Commands.DeleteSubject;
using Navz.UniversitySystem.Application.Subjects.Commands.UpdateSubject;
using Navz.UniversitySystem.Application.Subjects.Queries.GetSubject;
using Navz.UniversitySystem.Application.Subjects.Queries.GetSubjectList;
using Navz.UniversitySystem.Application.Subjects.Queries.GetUpdateSubject;

namespace Navz.UniversitySystem.WebUI.Controllers
{
    public class SubjectController : BaseController
    {
        public IActionResult Index() => View();

        public async Task<IActionResult> Get() => Json(await Mediator.Send(new GetSubjectListQuery()));

        public async Task<IActionResult> Detail(int ID) => View(await Mediator.Send(new GetSubjectQuery { ID = ID }));

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubjectCommand command) => Json(await Mediator.Send(command));

        public async Task<IActionResult> Edit(int ID) => View(await Mediator.Send(new UpdateSubjectQuery { ID = ID }));

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateSubjectCommand command) => Json(await Mediator.Send(command));

        public async Task<IActionResult> Delete(int ID) => Json(await Mediator.Send(new DeleteSubjectCommand { ID = ID }));
    }
}
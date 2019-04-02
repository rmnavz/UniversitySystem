using FluentValidation;

namespace Navz.UniversitySystem.Application.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty();
        }
    }
}

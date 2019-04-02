using FluentValidation;

namespace Navz.UniversitySystem.Application.Administrators.Commands.DeleteAdministrator
{
    public class DeleteAdministratorCommandValidator : AbstractValidator<DeleteAdministratorCommand>
    {
        public DeleteAdministratorCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty();
        }
    }
}

using FluentValidation;

namespace Navz.UniversitySystem.Application.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommandValidator : AbstractValidator<DeleteSubjectCommand>
    {
        public DeleteSubjectCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty();
        }
    }
}

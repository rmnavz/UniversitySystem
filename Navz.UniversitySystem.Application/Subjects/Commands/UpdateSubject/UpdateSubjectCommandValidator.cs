using FluentValidation;

namespace Navz.UniversitySystem.Application.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommandValidator : AbstractValidator<UpdateSubjectCommand>
    {
        public UpdateSubjectCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}

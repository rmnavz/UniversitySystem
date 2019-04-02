using FluentValidation;
using Navz.UniversitySystem.Persistence;
using System;
using System.Linq;

namespace Navz.UniversitySystem.Application.Administrators.Commands.CreateAdministrator
{
    public class CreateAdministratorCommandValidator : AbstractValidator<CreateAdministratorCommand>
    {
        public CreateAdministratorCommandValidator()
        {
            RuleFor(x => x.EmailAddress).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password);
        }
    }
}

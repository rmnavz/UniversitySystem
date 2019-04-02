using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navz.UniversitySystem.Application.Administrators.Commands.UpdateAdministrator
{
    public class UpdateAdministratorCommandValidator : AbstractValidator<UpdateAdministratorCommand>
    {
        public UpdateAdministratorCommandValidator()
        {
            RuleFor(x => x.EmailAddress).NotEmpty().EmailAddress();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}

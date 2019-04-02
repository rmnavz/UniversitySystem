using MediatR;
using Microsoft.AspNetCore.SignalR;
using Navz.UniversitySystem.Application.Hubs;
using Navz.UniversitySystem.Application.Interfaces;
using Navz.UniversitySystem.Common.Enums;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Domain.ValueObjects;
using Navz.UniversitySystem.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Administrators.Commands.CreateAdministrator
{
    public class CreateAdministratorCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public class Handler : IRequestHandler<CreateAdministratorCommand, Unit>
        {
            private readonly DatabaseContext _context;
            private readonly INotificationService _notificationService;
            private readonly IMediator _mediator;

            public Handler(
                DatabaseContext context,
                INotificationService notificationService,
                IMediator mediator)
            {
                _context = context;
                _notificationService = notificationService;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateAdministratorCommand request, CancellationToken cancellationToken)
            {
                var entity = new Administrator
                {
                    AdminType = AdminType.System,
                    User = new User
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        EmailAddress = request.EmailAddress,
                        Password = (Encrypted)request.Password,
                        UserType = UserType.Administrator,
                    }
                };

                _context.Administrators.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                
                await _mediator.Publish(new AdministratorCreated { AdministratorID = entity.ID });

                return Unit.Value;
            }
        }
    }
}

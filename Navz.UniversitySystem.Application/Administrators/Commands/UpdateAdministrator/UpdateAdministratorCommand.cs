using MediatR;
using Microsoft.EntityFrameworkCore;
using Navz.UniversitySystem.Application.Exceptions;
using Navz.UniversitySystem.Application.Interfaces;
using Navz.UniversitySystem.Common.Enums;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Administrators.Commands.UpdateAdministrator
{
    public class UpdateAdministratorCommand : IRequest
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? BirthDate { get; set; }
        public UserType UserType { get; set; }

        public class Handler : IRequestHandler<UpdateAdministratorCommand, Unit>
        {
            private readonly DatabaseContext _context;
            private readonly INotificationService _notificationService;
            private readonly IMediator _mediator;

            public Handler(
                    DatabaseContext context,
                    INotificationService notificationService,
                    IMediator mediator
                )
            {
                _context = context;
                _notificationService = notificationService;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateAdministratorCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Administrators
                    .Include(x => x.User)
                    .SingleAsync(c => c.ID == request.ID, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(User), request.ID);
                }

                entity.User.EmailAddress = request.EmailAddress;
                entity.User.UserType = request.UserType;
                entity.User.FirstName = request.FirstName;
                entity.User.LastName = request.LastName;

                _context.Administrators.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new AdministratorUpdated { AdministratorID = entity.ID });

                return Unit.Value;
            }
        }
    }
}

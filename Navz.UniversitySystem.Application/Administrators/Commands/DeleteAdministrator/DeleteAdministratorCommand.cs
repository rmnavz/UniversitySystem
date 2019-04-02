using MediatR;
using Navz.UniversitySystem.Application.Exceptions;
using Navz.UniversitySystem.Application.Interfaces;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Administrators.Commands.DeleteAdministrator
{
    public class DeleteAdministratorCommand : IRequest
    {
        public int ID { get; set; }

        public class Handler : IRequestHandler<DeleteAdministratorCommand, Unit>
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

            public async Task<Unit> Handle(DeleteAdministratorCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Administrators
                    .FindAsync(request.ID);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(User), request.ID);
                }

                _context.Administrators.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new AdministratorDeleted { AdministratorID = entity.ID });

                return Unit.Value;
            }
        }
    }
}

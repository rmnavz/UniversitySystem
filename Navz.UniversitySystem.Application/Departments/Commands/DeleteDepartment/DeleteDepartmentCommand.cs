using MediatR;
using Navz.UniversitySystem.Application.Exceptions;
using Navz.UniversitySystem.Application.Interfaces;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest
    {
        public int ID { get; set; }

        public class Handler : IRequestHandler<DeleteDepartmentCommand, Unit>
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

            public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Departments
                    .FindAsync(request.ID);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Department), request.ID);
                }

                _context.Departments.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new DepartmentDeleted { DepartmentID = entity.ID });

                return Unit.Value;
            }
        }
    }
}

using MediatR;
using Navz.UniversitySystem.Application.Exceptions;
using Navz.UniversitySystem.Application.Interfaces;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommand : IRequest
    {
        public int ID { get; set; }

        public class Handler : IRequestHandler<DeleteSubjectCommand, Unit>
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

            public async Task<Unit> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Departments
                    .FindAsync(request.ID);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Subject), request.ID);
                }

                _context.Departments.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new SubjectDeleted { SubjectID = entity.ID });

                return Unit.Value;
            }
        }
    }
}

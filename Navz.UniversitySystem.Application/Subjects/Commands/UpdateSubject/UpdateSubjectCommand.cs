using MediatR;
using Microsoft.EntityFrameworkCore;
using Navz.UniversitySystem.Application.Exceptions;
using Navz.UniversitySystem.Application.Interfaces;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommand : IRequest
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public class Handler : IRequestHandler<UpdateSubjectCommand, Unit>
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

            public async Task<Unit> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Departments
                    .SingleAsync(c => c.ID == request.ID, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Subject), request.ID);
                }

                entity.ID = request.ID;
                entity.Code = request.Code;
                entity.Name = request.Name;
                entity.Description = request.Description;

                _context.Departments.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new SubjectUpdated { SubjectID = entity.ID });

                return Unit.Value;
            }
        }
    }
}

using MediatR;
using Navz.UniversitySystem.Application.Interfaces;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommand : IRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public class Handler : IRequestHandler<CreateSubjectCommand, Unit>
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

            public async Task<Unit> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
            {
                var entity = new Subject
                {
                    Code = request.Code,
                    Name = request.Name,
                    Description = request.Description
                };

                _context.Subjects.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new SubjectCreated { SubjectID = entity.ID });

                return Unit.Value;
            }
        }
    }
}

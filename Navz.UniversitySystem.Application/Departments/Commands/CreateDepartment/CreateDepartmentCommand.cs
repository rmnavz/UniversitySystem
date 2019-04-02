using MediatR;
using Navz.UniversitySystem.Application.Interfaces;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public class Handler : IRequestHandler<CreateDepartmentCommand, Unit>
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

            public async Task<Unit> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
            {
                var entity = new Department
                {
                    Code = request.Code,
                    Name = request.Name,
                    Description = request.Description
                };

                _context.Departments.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new DepartmentCreated { DepartmentID = entity.ID });

                return Unit.Value;
            }
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Navz.UniversitySystem.Application.Exceptions;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Departments.Queries.GetDepartment
{
    public class GetDepartmentQuery : IRequest<DepartmentViewModel>
    {
        public int ID { get; set; }

        public class Handler : IRequestHandler<GetDepartmentQuery, DepartmentViewModel>
        {
            private readonly DatabaseContext _context;
            private readonly IMapper _mapper;

            public Handler(DatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DepartmentViewModel> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<DepartmentViewModel>(await _context.Departments
                    .Where(x => x.ID == request.ID)
                    .FirstOrDefaultAsync(cancellationToken));

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Department), request.ID);
                }

                // TODO: Set view model state based on user permissions.
                entity.EditEnabled = true;
                entity.DeleteEnabled = false;

                return entity;
            }
        }
    }
}

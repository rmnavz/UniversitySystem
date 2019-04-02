using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Navz.UniversitySystem.Application.Exceptions;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Departments.Queries.GetUpdateDepartment
{
    public class UpdateDepartmentQuery : IRequest<UpdateDepartmentViewModel>
    {
        public int ID { get; set; }

        public class Handler : IRequestHandler<UpdateDepartmentQuery, UpdateDepartmentViewModel>
        {
            private readonly DatabaseContext _context;
            private readonly IMapper _mapper;

            public Handler(DatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UpdateDepartmentViewModel> Handle(UpdateDepartmentQuery request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<UpdateDepartmentViewModel>(await _context.Departments
                    .Where(x => x.ID == request.ID)
                    .FirstOrDefaultAsync(cancellationToken));

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Department), request.ID);
                }

                return entity;
            }
        }
    }
}

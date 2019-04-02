using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Navz.UniversitySystem.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Departments.Queries.GetDepartmentList
{
    public class GetDepartmentListQuery : IRequest<DepartmentListViewModel>
    {
        public class Handler : IRequestHandler<GetDepartmentListQuery, DepartmentListViewModel>
        {
            private readonly DatabaseContext _context;
            private readonly IMapper _mapper;

            public Handler(DatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DepartmentListViewModel> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
            {
                return new DepartmentListViewModel
                {
                    Departments = await _context.Departments
                        .ProjectTo<DepartmentLookupModel>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken),
                    CreateEnabled = true
                };
            }
        }
    }
}

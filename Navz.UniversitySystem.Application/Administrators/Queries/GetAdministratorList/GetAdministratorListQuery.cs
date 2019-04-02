using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Navz.UniversitySystem.Common.Enums;
using Navz.UniversitySystem.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Administrators.Queries.GetAdministratorList
{
    public class GetAdministratorListQuery : IRequest<AdministratorListViewModel>
    {

        public class Handler : IRequestHandler<GetAdministratorListQuery, AdministratorListViewModel>
        {
            private readonly DatabaseContext _context;
            private readonly IMapper _mapper;

            public Handler(DatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AdministratorListViewModel> Handle(GetAdministratorListQuery request, CancellationToken cancellationToken)
            {
                return new AdministratorListViewModel
                {
                    Administrators = await _context.Administrators
                        .Include(x => x.User)
                        .ProjectTo<AdministratorLookupModel>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken),
                    CreateEnabled = true
                };
            }
        }
    }
}

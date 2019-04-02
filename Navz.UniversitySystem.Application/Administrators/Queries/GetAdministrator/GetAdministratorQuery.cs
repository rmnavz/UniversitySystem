using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Navz.UniversitySystem.Application.Exceptions;
using Navz.UniversitySystem.Common.Enums;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Administrators.Queries.GetAdministrator
{
    public class GetAdministratorQuery : IRequest<AdministratorViewModel>
    {
        public int ID { get; set; }

        public class Handler : IRequestHandler<GetAdministratorQuery, AdministratorViewModel>
        {
            private readonly DatabaseContext _context;
            private readonly IMapper _mapper;

            public Handler(DatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AdministratorViewModel> Handle(GetAdministratorQuery request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<AdministratorViewModel>(await _context.Administrators
                    .Include(x => x.User)
                    .Where(x =>
                        x.ID == request.ID)
                    .FirstOrDefaultAsync(cancellationToken));

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Administrator), request.ID);
                }

                // TODO: Set view model state based on user permissions.
                entity.EditEnabled = true;
                entity.DeleteEnabled = false;

                return entity;
            }
        }
    }
}

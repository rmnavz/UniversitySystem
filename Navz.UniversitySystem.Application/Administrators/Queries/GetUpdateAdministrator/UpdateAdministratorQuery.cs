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

namespace Navz.UniversitySystem.Application.Administrators.Queries.GetUpdateAdministrator
{
    public class UpdateAdministratorQuery : IRequest<UpdateAdministratorViewModel>
    {
        public int ID { get; set; }

        public class Handler : IRequestHandler<UpdateAdministratorQuery, UpdateAdministratorViewModel>
        {
            private readonly DatabaseContext _context;
            private readonly IMapper _mapper;

            public Handler(DatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UpdateAdministratorViewModel> Handle(UpdateAdministratorQuery request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<UpdateAdministratorViewModel>(await _context.Administrators
                    .Include(x => x.User)
                    .Where(x => x.ID == request.ID)
                    .FirstOrDefaultAsync(cancellationToken));

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Administrator), request.ID);
                }

                return entity;
            }
        }
    }
}

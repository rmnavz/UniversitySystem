using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Navz.UniversitySystem.Application.Exceptions;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Subjects.Queries.GetSubject
{
    public class GetSubjectQuery : IRequest<SubjectViewModel>
    {
        public int ID { get; set; }

        public class Handler : IRequestHandler<GetSubjectQuery, SubjectViewModel>
        {
            private readonly DatabaseContext _context;
            private readonly IMapper _mapper;

            public Handler(DatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SubjectViewModel> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<SubjectViewModel>(await _context.Departments
                    .Where(x => x.ID == request.ID)
                    .FirstOrDefaultAsync(cancellationToken));

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Subject), request.ID);
                }

                // TODO: Set view model state based on user permissions.
                entity.EditEnabled = true;
                entity.DeleteEnabled = false;

                return entity;
            }
        }
    }
}

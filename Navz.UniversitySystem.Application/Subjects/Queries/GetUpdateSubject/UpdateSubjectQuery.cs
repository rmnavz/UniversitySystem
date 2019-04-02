using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Navz.UniversitySystem.Application.Exceptions;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Subjects.Queries.GetUpdateSubject
{
    public class UpdateSubjectQuery : IRequest<UpdateSubjectViewModel>
    {
        public int ID { get; set; }

        public class Handler : IRequestHandler<UpdateSubjectQuery, UpdateSubjectViewModel>
        {
            private readonly DatabaseContext _context;
            private readonly IMapper _mapper;

            public Handler(DatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UpdateSubjectViewModel> Handle(UpdateSubjectQuery request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<UpdateSubjectViewModel>(await _context.Subjects
                    .Where(x => x.ID == request.ID)
                    .FirstOrDefaultAsync(cancellationToken));

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Subject), request.ID);
                }

                return entity;
            }
        }
    }
}

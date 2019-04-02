using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Navz.UniversitySystem.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Subjects.Queries.GetSubjectList
{
    public class GetSubjectListQuery : IRequest<SubjectListViewModel>
    {
        public class Handler : IRequestHandler<GetSubjectListQuery, SubjectListViewModel>
        {
            private readonly DatabaseContext _context;
            private readonly IMapper _mapper;

            public Handler(DatabaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SubjectListViewModel> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
            {
                return new SubjectListViewModel
                {
                    Subjects = await _context.Subjects
                        .ProjectTo<SubjectLookupModel>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken),
                    CreateEnabled = true
                };
            }
        }
    }
}

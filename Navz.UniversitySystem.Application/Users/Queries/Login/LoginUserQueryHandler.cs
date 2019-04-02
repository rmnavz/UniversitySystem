using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Navz.UniversitySystem.Common.Security;
using Navz.UniversitySystem.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Users.Queries.Login
{
    public class LoginUserQueryHandler : MediatR.IRequestHandler<LoginUserQuery, LoginDto>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public LoginUserQueryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LoginDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<LoginDto>(await _context
                .Users
                .Where(x => 
                    x.EmailAddress == request.EmailAddress &&
                    PasswordHasher.VerifyPassword(request.Password, x.Password.Salt, x.Password.Hash)
                    )
                .SingleOrDefaultAsync(cancellationToken));

            return user;
        }
    }
}

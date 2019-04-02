using MediatR;

namespace Navz.UniversitySystem.Application.Users.Queries.Login
{
    public class LoginUserQuery : IRequest<LoginDto>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}

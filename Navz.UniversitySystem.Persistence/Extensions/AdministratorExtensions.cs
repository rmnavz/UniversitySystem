using Navz.UniversitySystem.Domain.Entities;

namespace Navz.UniversitySystem.Persistence.Extensions
{
    public static class AdministratorExtensions
    {
        public static Administrator User(this Administrator administrator, User user)
        {
            administrator.User = user;
            return administrator;
        }
    }
}

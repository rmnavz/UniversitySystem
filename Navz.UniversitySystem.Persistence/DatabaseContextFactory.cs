using Microsoft.EntityFrameworkCore;
using Navz.UniversitySystem.Persistence.Infrastructure;

namespace Navz.UniversitySystem.Persistence
{
    public class DatabaseContextFactory : DesignTimeDbContextFactoryBase<DatabaseContext>
    {
        protected override DatabaseContext CreateNewInstance(DbContextOptions<DatabaseContext> options)
        {
            return new DatabaseContext(options);
        }
    }
}

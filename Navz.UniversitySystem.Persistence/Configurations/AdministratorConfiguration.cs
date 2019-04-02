using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Navz.UniversitySystem.Domain.Entities;

namespace Navz.UniversitySystem.Persistence.Configurations
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.ToTable("Administrators");

            builder.HasKey(x => x.ID);
        }
    }
}

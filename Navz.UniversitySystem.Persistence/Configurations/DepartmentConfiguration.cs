using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Navz.UniversitySystem.Domain.Entities;

namespace Navz.UniversitySystem.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasKey(x => x.ID);

            builder.HasMany(x => x.Subjects)
                .WithOne(x => x.Department);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Navz.UniversitySystem.Domain.Entities;

namespace Navz.UniversitySystem.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.ID);

            builder.OwnsOne(x => x.Password);

            builder.HasOne<Administrator>(x => x.Administrator)
                .WithOne(x => x.User)
                .HasForeignKey<Administrator>(x => x.ID);
        }
    }
}

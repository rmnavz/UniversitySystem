using Navz.UniversitySystem.Common.Enums;
using Navz.UniversitySystem.Domain.Entities;
using Navz.UniversitySystem.Domain.ValueObjects;
using Navz.UniversitySystem.Persistence.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Navz.UniversitySystem.Persistence
{
    public class DatabaseInitializer
    {
        private readonly Dictionary<int, User> Users = new Dictionary<int, User>();

        public static void Initialize(DatabaseContext context)
        {
            var initializer = new DatabaseInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return; // Db has been seeded
            }

            SeedAdministrators(context);

            SeedDepartments(context);
        }

        public void SeedAdministrators(DatabaseContext context)
        {
            var Administrators = new[]
            {
                new Administrator()
                {
                    AdminType = AdminType.Superuser
                }.User(
                    new User
                    {
                        FirstName = "super",
                        LastName = "user",
                        EmailAddress = "root@domain.com",
                        Password = (Encrypted)"P@ssw0rd",
                        UserType = UserType.Administrator
                    }
                )
            };

            context.Administrators.AddRange(Administrators);

            context.SaveChanges();
        }

        public void SeedDepartments(DatabaseContext context)
        {
            var Departments = new[]
            {
                new Department
                {
                    Code = "CS",
                    Name = "Computer Science"
                },
                new Department
                {
                    Code = "BA",
                    Name = "Business Administration"
                }
            };

            context.Departments.AddRange(Departments);

            context.SaveChanges();
        }
    }
}

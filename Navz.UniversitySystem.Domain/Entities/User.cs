using Navz.UniversitySystem.Common.Enums;
using Navz.UniversitySystem.Domain.Infrastructure;
using Navz.UniversitySystem.Domain.ValueObjects;
namespace Navz.UniversitySystem.Domain.Entities
{
    public class User : EntityObject
    {
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }
        public Encrypted Password { get; set; }

        public UserType UserType { get; set; }

        public virtual Administrator Administrator { get; set; }
        //public virtual Instructor Instructor { get; set; }
        //public virtual Student Student { get; set; }
    }
}

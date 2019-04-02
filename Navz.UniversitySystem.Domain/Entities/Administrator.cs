using Navz.UniversitySystem.Common.Enums;
using Navz.UniversitySystem.Domain.Infrastructure;

namespace Navz.UniversitySystem.Domain.Entities
{
    public class Administrator : EntityObject
    {
        public int ID { get; set; }
        public AdminType AdminType { get; set; }

        public virtual User User { get; set; }
    }
}

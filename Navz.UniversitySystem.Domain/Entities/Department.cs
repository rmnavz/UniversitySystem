using Navz.UniversitySystem.Domain.Infrastructure;
using System.Collections.Generic;

namespace Navz.UniversitySystem.Domain.Entities
{
    public class Department : EntityObject
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}

using Navz.UniversitySystem.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navz.UniversitySystem.Domain.Entities
{
    public class Subject : EntityObject
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Department Department { get; set; }
    }
}

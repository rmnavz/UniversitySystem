using Navz.UniversitySystem.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navz.UniversitySystem.Domain.Entities
{
    public class Instructor : EntityObject
    {
        public int ID { get; set; }

        public virtual Department Department { get; set; }
        public virtual User User { get; set; }
    }
}

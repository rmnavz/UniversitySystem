using Navz.UniversitySystem.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navz.UniversitySystem.Domain.Entities
{
    public class Class : EntityObject
    {
        public int ID { get; set; }


        public virtual Subject Subject { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Navz.UniversitySystem.Domain.Infrastructure
{
    public abstract class EntityObject
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}

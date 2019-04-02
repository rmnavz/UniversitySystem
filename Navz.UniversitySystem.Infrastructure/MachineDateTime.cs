using Navz.UniversitySystem.Common.Interfaces;
using System;

namespace Navz.UniversitySystem.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}

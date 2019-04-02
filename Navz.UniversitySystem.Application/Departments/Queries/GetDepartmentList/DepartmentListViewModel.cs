using System.Collections.Generic;

namespace Navz.UniversitySystem.Application.Departments.Queries.GetDepartmentList
{
    public class DepartmentListViewModel
    {
        public IList<DepartmentLookupModel> Departments { get; set; }
        public bool CreateEnabled { get; set; }
    }
}

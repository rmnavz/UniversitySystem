using System.Collections.Generic;

namespace Navz.UniversitySystem.Application.Administrators.Queries.GetAdministratorList
{
    public class AdministratorListViewModel
    {
        public IList<AdministratorLookupModel> Administrators { get; set; }
        public bool CreateEnabled { get; set; }
    }
}

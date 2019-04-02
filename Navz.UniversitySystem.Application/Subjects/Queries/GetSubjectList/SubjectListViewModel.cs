using System.Collections.Generic;

namespace Navz.UniversitySystem.Application.Subjects.Queries.GetSubjectList
{
    public class SubjectListViewModel
    {
        public IList<SubjectLookupModel> Subjects { get; set; }
        public bool CreateEnabled { get; set; }
    }
}

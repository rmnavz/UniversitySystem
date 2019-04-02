using AutoMapper;
using Navz.UniversitySystem.Application.Interfaces.Mapping;
using Navz.UniversitySystem.Domain.Entities;

namespace Navz.UniversitySystem.Application.Subjects.Queries.GetUpdateSubject
{
    public class UpdateSubjectViewModel : IHaveCustomMapping
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Subject, UpdateSubjectViewModel>()
                .ForMember(d => d.ID, opt => opt.MapFrom(s => s.ID))
                .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description));
        }
    }
}

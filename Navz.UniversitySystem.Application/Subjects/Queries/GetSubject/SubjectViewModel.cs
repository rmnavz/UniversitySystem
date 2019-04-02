using AutoMapper;
using Navz.UniversitySystem.Application.Interfaces.Mapping;
using Navz.UniversitySystem.Domain.Entities;
using System;

namespace Navz.UniversitySystem.Application.Subjects.Queries.GetSubject
{
    public class SubjectViewModel : IHaveCustomMapping
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool EditEnabled { get; set; }
        public bool DeleteEnabled { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Subject, SubjectViewModel>()
                    .ForMember(d => d.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
                    .ForMember(d => d.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>())
                    .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code))
                    .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                    .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                    .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created))
                    .ForMember(d => d.Modified, opt => opt.MapFrom(s => s.Modified));
        }

        public class PermissionsResolver : IValueResolver<Subject, SubjectViewModel, bool>
        {
            public bool Resolve(Subject source, SubjectViewModel destination, bool destMember, ResolutionContext context)
            {
                return false;
            }
        }
    }
}

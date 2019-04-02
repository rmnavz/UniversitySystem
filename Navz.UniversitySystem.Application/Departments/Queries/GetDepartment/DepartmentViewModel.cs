using AutoMapper;
using Navz.UniversitySystem.Application.Interfaces.Mapping;
using Navz.UniversitySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navz.UniversitySystem.Application.Departments.Queries.GetDepartment
{
    public class DepartmentViewModel : IHaveCustomMapping
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
            configuration.CreateMap<Department, DepartmentViewModel>()
                .ForMember(d => d.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(d => d.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created))
                .ForMember(d => d.Modified, opt => opt.MapFrom(s => s.Modified));
        }

        public class PermissionsResolver : IValueResolver<Department, DepartmentViewModel, bool>
        {
            public bool Resolve(Department source, DepartmentViewModel destination, bool destMember, ResolutionContext context)
            {
                return false;
            }
        }
    }
}

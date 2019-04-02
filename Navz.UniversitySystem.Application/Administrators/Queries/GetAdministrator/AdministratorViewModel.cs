using AutoMapper;
using Navz.UniversitySystem.Application.Interfaces.Mapping;
using Navz.UniversitySystem.Domain.Entities;
using System;

namespace Navz.UniversitySystem.Application.Administrators.Queries.GetAdministrator
{
    public class AdministratorViewModel : IHaveCustomMapping
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool EditEnabled { get; set; }
        public bool DeleteEnabled { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Administrator, AdministratorViewModel>()
                .ForMember(d => d.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(d => d.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => string.Join(" ", s.User.FirstName, s.User.LastName)))
                .ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => s.User.EmailAddress))
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created))
                .ForMember(d => d.Modified, opt => opt.MapFrom(s => s.Modified));
        }

        public class PermissionsResolver : IValueResolver<Administrator, AdministratorViewModel, bool>
        {
            public bool Resolve(Administrator source, AdministratorViewModel destination, bool destMember, ResolutionContext context)
            {
                return false;
            }
        }
    }
}

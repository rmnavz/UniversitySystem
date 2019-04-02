using AutoMapper;
using Navz.UniversitySystem.Application.Interfaces.Mapping;
using Navz.UniversitySystem.Common.Enums;
using Navz.UniversitySystem.Domain.Entities;
using System;

namespace Navz.UniversitySystem.Application.Administrators.Queries.GetUpdateAdministrator
{
    public class UpdateAdministratorViewModel : IHaveCustomMapping
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Administrator, UpdateAdministratorViewModel>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.User.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.User.LastName))
                .ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => s.User.EmailAddress));
        }
    }
}

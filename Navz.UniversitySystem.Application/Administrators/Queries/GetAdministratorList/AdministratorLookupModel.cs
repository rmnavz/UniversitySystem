using AutoMapper;
using Navz.UniversitySystem.Application.Interfaces.Mapping;
using Navz.UniversitySystem.Domain.Entities;

namespace Navz.UniversitySystem.Application.Administrators.Queries.GetAdministratorList
{
    public class AdministratorLookupModel : IHaveCustomMapping
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Administrator, AdministratorLookupModel>()
                .ForMember(d => d.ID, opt => opt.MapFrom(s => s.ID))
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => string.Join(" ", s.User.FirstName, s.User.LastName)))
                .ForMember(d => d.EmailAddress, opt => opt.MapFrom((s => s.User.EmailAddress)));
        }
    }
}

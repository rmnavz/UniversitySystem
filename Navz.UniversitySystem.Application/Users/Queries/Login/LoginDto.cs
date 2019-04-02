using AutoMapper;
using Navz.UniversitySystem.Application.Interfaces.Mapping;
using Navz.UniversitySystem.Common.Enums;
using Navz.UniversitySystem.Domain.Entities;

namespace Navz.UniversitySystem.Application.Users.Queries.Login
{
    public class LoginDto : IHaveCustomMapping
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public UserType UserType { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<User, LoginDto>()
                .ForMember(d => d.ID, opt => opt.MapFrom(s => s.ID))
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => string.Join(" ", s.FirstName, s.LastName)))
                .ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => s.EmailAddress))
                .ForMember(d => d.UserType, opt => opt.MapFrom(s => s.UserType));
        }
    }
}

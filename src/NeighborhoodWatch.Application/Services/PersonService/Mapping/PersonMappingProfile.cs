using AutoMapper;
using MovieListAbpApp.Domain;
using MovieListAbpApp.Services.PersonService.Dtos;
using NeighborhoodWatch.Authorization.Users;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.AddressService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListAbpApp.Services.PersonService.Mapping
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(x => x.userId, m => m.MapFrom(x => x.User != null ? x.User.Id : (long?)null))
                .ForMember(x => x.Address, m => m.MapFrom(x => x.Address != null ? x.Address.Id : (Guid?)null))
                .ForMember(x => x.Address, m => m.MapFrom(x => x.Address)); // Map Address to AddressDto

            CreateMap<Address, AddressDto>(); // Map Address to AddressDto

            CreateMap<PersonDto, User>()
                .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
                .ForMember(x => x.PhoneNumber, m => m.MapFrom(x => x.PhoneNumber))
                .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.EmailAddress))
                .ForMember(x => x.FullName, m => m.MapFrom(x => x.Name + " " + x.Surname))
                .ForMember(x => x.Password, m => m.MapFrom(x => x.Password))
                .ForMember(x => x.Surname, m => m.MapFrom(x => x.Surname))
                .ForMember(x => x.UserName, m => m.MapFrom(x => x.Name + x.Surname.Substring(0, 4)));

            CreateMap<PersonDto, User>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<PersonDto, Address>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<PersonDto, Person>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}

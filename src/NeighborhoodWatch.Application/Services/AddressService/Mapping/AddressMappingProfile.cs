using AutoMapper;
using MovieListAbpApp.Services.PersonService.Dtos;
using NeighborhoodWatch.Authorization.Users;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.AddressService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.AddressService.Mapping
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<AddressDto, Address>()
                .ForMember(x => x.Id, m => m.MapFrom(a => a.Id))
                .ForMember(x => x.Street, m => m.MapFrom(a => a.Street))
                .ForMember(x => x.Town, m => m.MapFrom(a => a.Town))
                .ForMember(x => x.City, m => m.MapFrom(a => a.City))
                .ForMember(x => x.Province, m => m.MapFrom(a => a.Province))
                .ForMember(x => x.PostalCode, m => m.MapFrom(a => a.PostalCode));
            CreateMap<AddressDto, Address>()
               .ForMember(e => e.Id, d => d.Ignore());

        }
    }
}

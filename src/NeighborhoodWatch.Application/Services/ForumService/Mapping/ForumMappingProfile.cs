using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AutoMapper;
using MovieListAbpApp.Domain;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.ForumService.Dto;
using System;

namespace NeighborhoodWatch.Services.ForumService.Mapping
{
    public class ForumMappingProfile : Profile
    {
        public ForumMappingProfile()
        {
            CreateMap<Forum, ForumDto>()
                .ForMember(x => x.PersonId, m => m.MapFrom(x => x.Person != null ? x.Person.Id : (Guid?)null))
                .ForMember(x => x.CreatedTime, m => m.MapFrom(src => src.CreationTime)); 

            CreateMap<ForumDto, Forum>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}

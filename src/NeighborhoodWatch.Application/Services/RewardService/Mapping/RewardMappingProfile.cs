using AutoMapper;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.IncidentReport.Dtos;
using NeighborhoodWatch.Services.RewardService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.RewardService.Mapping
{
    public class RewardMappingProfile : Profile
    {
        public RewardMappingProfile()
        {
            CreateMap<Reward, RewardDto>()
                .ForMember(x => x.PersonId, m => m.MapFrom(x => x.Person != null ? x.Person.Id : (Guid?)null))
                .ForMember(x => x.RewardDate, m => m.MapFrom(src => src.CreationTime));
        }
    }
}

using Abp.Dependency;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using AutoMapper;
using MovieListAbpApp.Domain;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.ForumService.Dto;
using NeighborhoodWatch.Services.IncidentReport.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.ForumService.Mapping
{
    public class ForumMappingProfile : Profile
    {
        public ForumMappingProfile()
        {
            CreateMap<Forum, ForumDto>()
              .ForMember(x => x.PersonId, m => m.MapFrom(x => x.Person != null ? x.Person.Id : (Guid?)null));

            CreateMap<ForumDto, Forum>()
               .ForMember(e => e.Id, d => d.Ignore());

            /*            CreateMap<ForumDto, Forum>()
                    .ForMember(e => e.Person, d => d.MapFrom(x => GetEntity<Person>(x.PersonId)));*/
        }
/*        private T GetEntity<T>(Guid id) where T : AuditedEntity<Guid>
        {
            var repo = IocManager.Instance.Resolve<IRepository<T, Guid>>();

            return repo.Get(id);
        }*/

    }
}

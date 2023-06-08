using Abp.Dependency;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using AutoMapper;
using MovieListAbpApp.Domain;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.IncidentReport.Dtos;
using NeighborhoodWatch.Services.PatrollingRequestService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.IncidentReport.Mapping
{
    public class IncidentMappingProfile : Profile
    {
       public IncidentMappingProfile()
        {
            CreateMap<Incident, IncidentDto>()
                .ForMember(x => x.PersonId, m => m.MapFrom(x => x.Person != null ? x.Person.Id : (Guid?)null))
               .ForMember(x => x.Fileid, m => m.MapFrom(x => x.Picture != null ? x.Picture.Id : (Guid?)null))
               .ForMember(x => x.AddressId, m => m.MapFrom(x => x.Address != null ? x.Address.Id : (Guid?)null));
            /* .ForMember(x => x.Picture, m => m.Ignore());*/

            /*            CreateMap<IncidentDto, Incident>()
                            .ForMember(e => e.Person, d => d.MapFrom(x => GetEntity<Person>(x.PersonId)));*/
        }
/*        private T GetEntity<T>(Guid id) where T : AuditedEntity<Guid>
        {
            var repo = IocManager.Instance.Resolve<IRepository<T, Guid>>();

            return repo.Get(id);
        }*/

    }
    
}

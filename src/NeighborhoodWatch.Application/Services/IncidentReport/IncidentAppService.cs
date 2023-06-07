using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using MovieListAbpApp.Domain;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.Helpers;
using NeighborhoodWatch.Services.IncidentReport.Dtos;
using NeighborhoodWatch.Services.StoredFileService.Dtos;
using NeighborhoodWatch.Services.StoredFileService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.IncidentReport
{
    public class IncidentAppService : ApplicationService, IIncidentAppService
    {
        private readonly IRepository<Incident, Guid> _incidentRepository;
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IRepository<Address, Guid> _addressRepository;

        public IncidentAppService(
            IRepository<Incident, Guid> incidentRepository,
            IRepository<Person, Guid> personRepository,
            IRepository<Address, Guid> addressRepository)
        {
            _incidentRepository = incidentRepository;
            _personRepository = personRepository;
            _addressRepository = addressRepository;
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IncidentDto> CreateAsync([FromForm]IncidentDto incident)
        { 
            if (!Utils.IsImage(incident.Picture))
                throw new ArgumentException("The file is not a valid image.");

            var entity = ObjectMapper.Map<Incident>(incident);
            entity.Person =  _personRepository.Get(incident.PersonId);
            entity.Address =  _addressRepository.Get(incident.AddressId);
            if (incident.Picture != null)
            {
                var storedFileService = IocManager.Instance.Resolve<StoredFileAppService>();
                var storedFileDto = new StoredFileDto() { File = incident.Picture };
                entity.Picture = await storedFileService.CreateStoredFile(storedFileDto);
            }

            var createdEntity = await _incidentRepository.InsertAsync(entity);
            return ObjectMapper.Map<IncidentDto>(createdEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _incidentRepository.GetAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Incident not found", nameof(id));
            }

            await _incidentRepository.DeleteAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResultDto<IncidentDto>> GetAllAsync(PagedAndSortedResultRequestDto pagedAndSortedResultRequestDto)
        {
            var entities = _incidentRepository
                .GetAllIncluding(m => m.Person, mbox => mbox.Address).ToList();
            var totalCount = entities.Count;

            var dtos = ObjectMapper.Map<List<IncidentDto>>(entities);

            return new PagedResultDto<IncidentDto>(totalCount, dtos);
        }

        public async Task<IncidentDto> GetAsync(Guid guid)
        {
            var entity = _incidentRepository
                .GetAllIncluding(m => m.Person, mbox => mbox.Address)
                .FirstOrDefault(x => x.Id == guid);

            return ObjectMapper.Map<IncidentDto>(entity);
        }

        public async Task<IncidentDto> UpdateAsync(IncidentDto incident)
        {
            var entity = _incidentRepository
                .GetAllIncluding(m => m.Person, mbox => mbox.Address)
                .FirstOrDefault(x => x.Id == incident.Id);

            if (entity == null)
            {
                throw new ArgumentException("Incident not found", nameof(incident.Id));
            }

            ObjectMapper.Map(incident, entity);

            var updatedEntity = await _incidentRepository.UpdateAsync(entity);
            return ObjectMapper.Map<IncidentDto>(updatedEntity);
        }
    }
}

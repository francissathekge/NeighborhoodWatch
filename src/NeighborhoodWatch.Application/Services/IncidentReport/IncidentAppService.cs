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
using Microsoft.EntityFrameworkCore;

namespace NeighborhoodWatch.Services.IncidentReport
{
    public class IncidentAppService : ApplicationService, IIncidentAppService
    {
        private readonly IRepository<Incident, Guid> _incidentRepository;
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IRepository<Address, Guid> _addressRepository;
        private readonly IRepository<StoredFile, Guid> _storedFileRepository;
 


        public IncidentAppService(
            IRepository<Incident, Guid> incidentRepository,
            IRepository<Person, Guid> personRepository,
            IRepository<Address, Guid> addressRepository,
            IRepository<StoredFile, Guid> StoredFileRepository)
        {
            _incidentRepository = incidentRepository;
            _personRepository = personRepository;
            _addressRepository = addressRepository;
            _storedFileRepository = StoredFileRepository;
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IncidentDto> CreateAsync([FromForm] IncidentDto incident)
        {
            var userId = AbpSession.UserId;
            var person = await _personRepository.GetAllIncluding(a => a.Address).Where(a => a.User.Id == userId).FirstOrDefaultAsync();
            /*
                        var userId = AbpSession.UserId;
                        var person = await _personRepository.FirstOrDefaultAsync(a => a.User.Id == userId);*/

            var entity = ObjectMapper.Map<Incident>(incident);
            entity.Person = person;
            entity.Address = person.Address;

            if (incident.File != null && !Utils.IsImage(incident.File))
                throw new ArgumentException("The file is not a valid image.");

            if (incident.File != null)
            {
                var storedFileService = IocManager.Instance.Resolve<StoredFileAppService>();
                var storedFileDto = new StoredFileDto() { File = incident.File };
                entity.Picture = await storedFileService.CreateStoredFile(storedFileDto);
            }
            else
            {
                entity.Picture = null; // Set Picture property to null if the file is null
            }

            return ObjectMapper.Map<IncidentDto>(await _incidentRepository.InsertAsync(entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetStoredFile(Guid id)
        {
            var service = _incidentRepository.GetAllIncluding(x => x.Picture).FirstOrDefault(y => y.Id == id);
            var storedFileService = IocManager.Instance.Resolve<StoredFileAppService>();
            return await storedFileService.GetStoredFile(service.Picture.Id);
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
                .GetAllIncluding(m => m.Person, mbox => mbox.Address, p=> p.Picture).ToList();
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

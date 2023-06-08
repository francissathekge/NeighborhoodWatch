using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieListAbpApp.Domain;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.PatrollingRequestService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.PatrollingRequestService
{
    public class PatrollingRequestAppService : ApplicationService, IPatrollingRequestAppService
    {
        private readonly IRepository<PatrollingRequest, Guid> _patrollingRequestRepository;
        private readonly IRepository<Person, Guid> _PersonRepository;
        private readonly IRepository<Address, Guid> _addressRepository;

        public PatrollingRequestAppService(IRepository<PatrollingRequest, Guid> patrollingRequestRepository, IRepository<Person, Guid> personRepository,
            IRepository<Address, Guid> addressRepository)
        {
            _patrollingRequestRepository = patrollingRequestRepository;
            _PersonRepository = personRepository;
            _addressRepository = addressRepository;
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<PatrollingRequestDto> CreateAsync([FromForm] PatrollingRequestDto patrollingRequest)
        {
            var userId = AbpSession.UserId;
            var person = await _PersonRepository.GetAllIncluding(a => a.Address).Where(a => a.User.Id == userId).FirstOrDefaultAsync();

            var entity = ObjectMapper.Map<PatrollingRequest>(patrollingRequest);
            entity.Person = person;
            entity.Address = person.Address;
            /*          var entity = ObjectMapper.Map<PatrollingRequest>(patrollingRequest);
                      entity.Person = _PersonRepository.Get(patrollingRequest.PersonId);
                      entity.Address=_addressRepository.Get(patrollingRequest.AddressId);*/


            return ObjectMapper.Map<PatrollingRequestDto>(await _patrollingRequestRepository.InsertAsync(entity));
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _patrollingRequestRepository.GetAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Patrolling Request not found", nameof(id));
            }
            await _patrollingRequestRepository.DeleteAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResultDto<PatrollingRequestDto>> GetAllAsync(PagedAndSortedResultRequestDto pagedAndSortedResultRequestDto)
        {
            var entities =  _patrollingRequestRepository.GetAllIncluding(m=>m.Person,mbox=>mbox.Address).ToList();
            var totalCount = entities.Count;

            var dtos = ObjectMapper.Map<List<PatrollingRequestDto>>(entities);

            return new PagedResultDto<PatrollingRequestDto>(totalCount, dtos);
        }

        public async Task<PatrollingRequestDto> GetAsync( Guid guid)
        {
            var entitie = _patrollingRequestRepository.GetAllIncluding(m => m.Person, mbox => mbox.Address).FirstOrDefault(x=>x.Id==guid);
            //var totalCount = entities.Count;
            return ObjectMapper.Map<PatrollingRequestDto>(entitie);
        }

        public async Task<PatrollingRequestDto> UpdateAsync(PatrollingRequestDto patrollingRequest)
        {
            var entity = _patrollingRequestRepository.GetAllIncluding(m => m.Person, mbox => mbox.Address).FirstOrDefault(x => x.Id == patrollingRequest.Id);
            if (entity == null)
            {
                throw new ArgumentException("Patrolling Request not found", nameof(patrollingRequest.Id));
            }

            ObjectMapper.Map(patrollingRequest, entity);

            return ObjectMapper.Map<PatrollingRequestDto>(await _patrollingRequestRepository.UpdateAsync(entity));
        }
    }
}

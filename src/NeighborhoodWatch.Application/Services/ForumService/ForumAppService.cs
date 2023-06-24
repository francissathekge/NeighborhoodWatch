using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieListAbpApp.Domain;
using NeighborhoodWatch.Authorization.Users;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.ForumService.Dto;
using NeighborhoodWatch.Services.IncidentReport.Dtos;
using NeighborhoodWatch.Services.PatrollingRequestService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.ForumService
{
    public class ForumAppService : ApplicationService, IForumAppService
    {
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IRepository<Forum, Guid> _forumRepository;

        public ForumAppService(
             IRepository<Person, Guid> personRepository,
             IRepository<Forum, Guid> forumRepository)
        {
            _personRepository = personRepository;
            _forumRepository = forumRepository;
        }
        [HttpPost]
        
        public async Task<ForumDto> CreateAsync(ForumDto forum)
        {
            var userId = AbpSession.UserId;
            var person = await _personRepository.FirstOrDefaultAsync(a => a.User.Id == userId);

            var entity = ObjectMapper.Map<Forum>(forum);
            entity.Person = person;



            //var entity = ObjectMapper.Map<Forum>(forum);
            //entity.Person = _personRepository.Get(forum.PersonId);

            return ObjectMapper.Map<ForumDto>(await _forumRepository.InsertAsync(entity));
        }

        public async Task DeleteAsync(Guid id)
        {
           var entity = await _forumRepository.GetAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Forum Request not found", nameof(id));
            }
            await _forumRepository.DeleteAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResultDto<ForumDto>> GetAllAsync(PagedAndSortedResultRequestDto pagedAndSortedResultRequestDto)
        {
            var entities = _forumRepository.GetAllIncluding(m => m.Person).ToList();
            var totalCount = entities.Count;

            var dtos = ObjectMapper.Map<List<ForumDto>>(entities);
            return new PagedResultDto<ForumDto>(totalCount, dtos);
        }

        public async Task<ForumDto> GetAsync(Guid guid)
        {
            var entitie = _forumRepository.GetAllIncluding(m => m.Person).FirstOrDefault(x => x.Id == guid);
           /* var totalCount = entitie.Count;*/
            return ObjectMapper.Map<ForumDto>(entitie);
        }

   
    }
}

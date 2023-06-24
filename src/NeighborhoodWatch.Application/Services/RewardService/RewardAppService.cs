using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using MovieListAbpApp.Domain;
using NeighborhoodWatch.Domain;

using NeighborhoodWatch.Services.RewardService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeighborhoodWatch.Services.StoredImageService.Dtos;
using NeighborhoodWatch.Services.Helpers;
using NeighborhoodWatch.Services.StoredImageService;
using NeighborhoodWatch.Services.ForumService.Dto;

namespace NeighborhoodWatch.Services.RewardService
{
    public class RewardAppService : ApplicationService, IRewardAppService
    {
        private readonly IRepository<Reward, Guid> _RewardRepository;
        private readonly IRepository<Person, Guid> _personRepository;

        public RewardAppService(IRepository<Reward, Guid> rewardRepository, IRepository<Person, Guid> personRepository)
        {
            _RewardRepository = rewardRepository;
            _personRepository = personRepository;
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<RewardDto> CreateAsync([FromForm] RewardDto reward)
        {
            var userId = AbpSession.UserId;
            var person = await _personRepository.FirstOrDefaultAsync(a => a.User.Id == userId);

            var entity = ObjectMapper.Map<Reward>(reward);
            entity.Person = person;

            if (reward.File != null && !Utils.IsImage(reward.File))
                throw new ArgumentException("The file is not a valid image.");

            if (reward.File != null)
            {
                var storedFileService = IocManager.Instance.Resolve<StoredImageAppService>();
                var storedFileDto = new StoredImageDto() { Files = reward.File };
                entity.Picture = await storedFileService.CreateStoredFileImages(storedFileDto);
            }
            else
            {
                entity.Picture = null; // Set Picture property to null if the file is null
            }

            //var entity = ObjectMapper.Map<Forum>(forum);
            //entity.Person = _personRepository.Get(forum.PersonId);

            return ObjectMapper.Map<RewardDto>(await _RewardRepository.InsertAsync(entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetStoredFile(Guid id)
        {
            var service = _RewardRepository.GetAllIncluding(x => x.Picture).FirstOrDefault(y => y.Id == id);
            var storedFileService = IocManager.Instance.Resolve<StoredImageAppService>();
            return await storedFileService.GetStoredFileImages(service.Picture.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _RewardRepository.GetAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Reward Request not found", nameof(id));
            }
            await _RewardRepository.DeleteAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResultDto<RewardDto>> GetAllAsync(PagedAndSortedResultRequestDto pagedAndSortedResultRequestDto)
        {
            var entities = _RewardRepository.GetAllIncluding(m => m.Person, x=> x.Picture).ToList();
            var totalCount = entities.Count;

            var dtos = ObjectMapper.Map<List<RewardDto>>(entities);
            return new PagedResultDto<RewardDto>(totalCount, dtos);
        }

        public Task<RewardDto> GetAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<RewardDto> UpdateAsync(RewardDto reward)
        {
            throw new NotImplementedException();
        }
    }
}

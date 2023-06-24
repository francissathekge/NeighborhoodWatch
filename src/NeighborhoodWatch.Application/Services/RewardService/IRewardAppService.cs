using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NeighborhoodWatch.Services.RewardService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.RewardService
{
    public interface IRewardAppService : IApplicationService
    {
        Task<RewardDto> CreateAsync(RewardDto reward);
        Task<RewardDto> UpdateAsync(RewardDto reward);
        Task<PagedResultDto<RewardDto>> GetAllAsync(PagedAndSortedResultRequestDto pagedAndSortedResultRequestDto);
        Task<RewardDto> GetAsync(Guid guid);
        Task DeleteAsync(Guid id);


    }
}

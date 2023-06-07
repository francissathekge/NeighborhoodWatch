using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NeighborhoodWatch.Services.PatrollingRequestService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.PatrollingRequestService
{
    public interface IPatrollingRequestAppService :IApplicationService
    {
        Task<PatrollingRequestDto> CreateAsync(PatrollingRequestDto patrollingRequest);
        Task<PatrollingRequestDto> UpdateAsync(PatrollingRequestDto patrollingRequest);
        Task<PagedResultDto<PatrollingRequestDto>> GetAllAsync(PagedAndSortedResultRequestDto pagedAndSortedResultRequestDto);
        Task<PatrollingRequestDto> GetAsync( Guid guid);
        Task DeleteAsync(Guid id);

    }
}

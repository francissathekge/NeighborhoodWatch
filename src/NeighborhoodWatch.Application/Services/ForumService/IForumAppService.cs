using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NeighborhoodWatch.Domain;
using NeighborhoodWatch.Services.ForumService.Dto;
using NeighborhoodWatch.Services.IncidentReport.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.ForumService
{
    public interface IForumAppService : IApplicationService
    {
        Task<ForumDto> CreateAsync(ForumDto forum);
        Task<PagedResultDto<ForumDto>> GetAllAsync(PagedAndSortedResultRequestDto pagedAndSortedResultRequestDto);
        Task<ForumDto> GetAsync(Guid guid);
        Task DeleteAsync(Guid id);
    }
}

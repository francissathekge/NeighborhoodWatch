using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NeighborhoodWatch.Services.IncidentReport.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodWatch.Services.IncidentReport
{
    public interface IIncidentAppService: IApplicationService
    {
        Task<IncidentDto> CreateAsync(IncidentDto incident);
        Task<IncidentDto> UpdateAsync(IncidentDto incident);
        Task<PagedResultDto<IncidentDto>> GetAllAsync(PagedAndSortedResultRequestDto pagedAndSortedResultRequestDto);
        Task<IncidentDto> GetAsync(Guid guid);
        Task DeleteAsync(Guid id);
    }
}

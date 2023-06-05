using Abp.Application.Services;
using NeighborhoodWatch.MultiTenancy.Dto;

namespace NeighborhoodWatch.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


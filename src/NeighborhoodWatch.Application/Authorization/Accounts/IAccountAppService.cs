using System.Threading.Tasks;
using Abp.Application.Services;
using NeighborhoodWatch.Authorization.Accounts.Dto;

namespace NeighborhoodWatch.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

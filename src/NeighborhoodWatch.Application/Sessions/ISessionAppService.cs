using System.Threading.Tasks;
using Abp.Application.Services;
using NeighborhoodWatch.Sessions.Dto;

namespace NeighborhoodWatch.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

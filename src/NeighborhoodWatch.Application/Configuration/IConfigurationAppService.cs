using System.Threading.Tasks;
using NeighborhoodWatch.Configuration.Dto;

namespace NeighborhoodWatch.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

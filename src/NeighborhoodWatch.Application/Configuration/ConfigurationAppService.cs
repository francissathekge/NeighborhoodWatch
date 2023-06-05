using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using NeighborhoodWatch.Configuration.Dto;

namespace NeighborhoodWatch.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : NeighborhoodWatchAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

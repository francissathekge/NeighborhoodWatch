using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace NeighborhoodWatch.Controllers
{
    public abstract class NeighborhoodWatchControllerBase: AbpController
    {
        protected NeighborhoodWatchControllerBase()
        {
            LocalizationSourceName = NeighborhoodWatchConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NeighborhoodWatch.Configuration;

namespace NeighborhoodWatch.Web.Host.Startup
{
    [DependsOn(
       typeof(NeighborhoodWatchWebCoreModule))]
    public class NeighborhoodWatchWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public NeighborhoodWatchWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NeighborhoodWatchWebHostModule).GetAssembly());
        }
    }
}

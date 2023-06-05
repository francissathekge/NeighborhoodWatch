using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NeighborhoodWatch.Configuration;
using NeighborhoodWatch.EntityFrameworkCore;
using NeighborhoodWatch.Migrator.DependencyInjection;

namespace NeighborhoodWatch.Migrator
{
    [DependsOn(typeof(NeighborhoodWatchEntityFrameworkModule))]
    public class NeighborhoodWatchMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public NeighborhoodWatchMigratorModule(NeighborhoodWatchEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(NeighborhoodWatchMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                NeighborhoodWatchConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NeighborhoodWatchMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}

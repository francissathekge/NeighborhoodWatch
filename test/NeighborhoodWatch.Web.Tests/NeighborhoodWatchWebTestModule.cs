using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NeighborhoodWatch.EntityFrameworkCore;
using NeighborhoodWatch.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace NeighborhoodWatch.Web.Tests
{
    [DependsOn(
        typeof(NeighborhoodWatchWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class NeighborhoodWatchWebTestModule : AbpModule
    {
        public NeighborhoodWatchWebTestModule(NeighborhoodWatchEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NeighborhoodWatchWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(NeighborhoodWatchWebMvcModule).Assembly);
        }
    }
}
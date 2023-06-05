using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using NeighborhoodWatch.EntityFrameworkCore.Seed;

namespace NeighborhoodWatch.EntityFrameworkCore
{
    [DependsOn(
        typeof(NeighborhoodWatchCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class NeighborhoodWatchEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<NeighborhoodWatchDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        NeighborhoodWatchDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        NeighborhoodWatchDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NeighborhoodWatchEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}

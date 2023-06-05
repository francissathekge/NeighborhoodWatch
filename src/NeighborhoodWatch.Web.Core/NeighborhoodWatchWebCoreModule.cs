using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using NeighborhoodWatch.Authentication.JwtBearer;
using NeighborhoodWatch.Configuration;
using NeighborhoodWatch.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace NeighborhoodWatch
{
    [DependsOn(
         typeof(NeighborhoodWatchApplicationModule),
         typeof(NeighborhoodWatchEntityFrameworkModule),
         typeof(AbpAspNetCoreModule)
        ,typeof(AbpAspNetCoreSignalRModule)
     )]
    public class NeighborhoodWatchWebCoreModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public NeighborhoodWatchWebCoreModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                NeighborhoodWatchConsts.ConnectionStringName
            );

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(NeighborhoodWatchApplicationModule).GetAssembly()
                 );

            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NeighborhoodWatchWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(NeighborhoodWatchWebCoreModule).Assembly);
        }
    }
}

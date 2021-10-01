using Premier.API.Core.Contracts;

using Premier.API.Core.Infrastructure.Configs;
using Premier.API.Core.Infrastructure.Handlers;
using Premier.API.Core.Services;

using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Premier.API.FileUploadDownload.Data.Contexts;

namespace Premier.API.FileUploadDownload.Infrastructure.Installers
{
    internal class RegisterOptions : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            var policyConfigs = new TenantDataOptions();
            config.Bind("TenantDataOptions", policyConfigs);


            services.AddOptions<TenantDataOptions>()
           .Bind(config.GetSection("TenantDataOptions"))
           .ValidateDataAnnotations();
        }
    }
}



using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Premier.API.Core.Contracts;
using Premier.API.FileUploadDownload.Services;

namespace Premier.API.FileUploadDownload.Infrastructure.Installers
{
    internal class RegisterApplicationServices : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            // All services that implement the IBaseService in the current assembly
            var baseAPIServiceType = typeof(IBaseService);
            var assembly = baseAPIServiceType.Assembly;

            var appServiceTypes = new List<Type>();
            appServiceTypes.AddRange(assembly.GetTypes()
               .Where(x => x.IsClass && !x.IsAbstract && baseAPIServiceType.IsAssignableFrom(x)));

            foreach (var appService in appServiceTypes)
            {
                services.AddTransient(appService);
            }
        }
    }
}



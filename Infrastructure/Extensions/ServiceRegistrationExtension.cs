using System;
using System.Linq;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Premier.API.Core.Contracts;

namespace Premier.API.FileUploadDownload.Infrastructure.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static void AddServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            // register all service installers
            var appServices = typeof(Startup).Assembly.DefinedTypes
                            .Where(x => typeof(IServiceRegistration)
                            .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                            .Select(Activator.CreateInstance)
                            .Cast<IServiceRegistration>().ToList();

            appServices.ForEach(svc => svc.RegisterAppServices(services, configuration));
        }
    }
}

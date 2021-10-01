using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Premier.API.Core.Contracts;
using Premier.API.Core.Data.DataServices;

namespace Premier.API.FileUploadDownload.Infrastructure.Installers
{
    internal class RegisterDataServices : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            // All services that implement the IBaseService in the current assembly
            var baseInterface = typeof(Startup);
            var baseAssembly = baseInterface.Assembly;

            var dataServiceInterface = typeof(IDataServices);

            var dataServiceTypes = new List<Type>();
            dataServiceTypes.AddRange(baseAssembly.GetTypes()
               .Where(x => x.IsClass && !x.IsAbstract && dataServiceInterface.IsAssignableFrom(x)));

            foreach (var dataService in dataServiceTypes)
            {
                services.AddTransient(dataService);
            }
        }
    }
}
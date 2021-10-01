using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Premier.API.Core.Contracts;
using Premier.API.Core.Data.Repositories;

using Premier.API.FileUploadDownload.Data.Repositories;

namespace Premier.API.FileUploadDownload.Infrastructure.Installers
{
    internal class RegisterUnitsOfWork : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            // All services that implement the IBaseService in the current assembly
            var baseInterface = typeof(Startup);
            var baseAssembly = baseInterface.Assembly;

            var unitOfWorkInterface = typeof(IUnitOfWork);

            var unitOfWorkTypes = new List<Type>();
            unitOfWorkTypes.AddRange(baseAssembly.GetTypes()
               .Where(x => x.IsClass && !x.IsAbstract && unitOfWorkInterface.IsAssignableFrom(x)));

            foreach (var unitOfWork in unitOfWorkTypes)
            {
                services.AddTransient(unitOfWork);
            }
        }
    }
}



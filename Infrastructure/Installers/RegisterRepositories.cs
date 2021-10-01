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
    internal class RegisterRepositories : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            // All services that implement the IBaseService in the current assembly
            var baseInterface = typeof(Startup);
            var baseAssembly = baseInterface.Assembly;

            var genericRepoInterface = typeof(IGenericRepository<>);

            // Get all local repositories implementations that implement the generic repository
            var repoImplementations = 
                from x in baseAssembly.GetTypes()
                from z in x.GetInterfaces()
                let y = x.BaseType
                where
                    (y != null && y.IsGenericType &&
                    genericRepoInterface.IsAssignableFrom(y.GetGenericTypeDefinition())) ||
                    (z.IsGenericType &&
                    genericRepoInterface.IsAssignableFrom(z.GetGenericTypeDefinition()))
                select x;

            // Add all repositories that implement local repository interfaces
            foreach(Type repoImplementation in repoImplementations)
            {
                // register concrete repositories
                var repositoryTypes = new List<Type>();
                repositoryTypes.AddRange(baseAssembly.GetTypes()
                   .Where(x => x.IsClass && !x.IsAbstract && repoImplementation.IsAssignableFrom(x)));

                foreach (var repository in repositoryTypes)
                {
                    services.AddScoped(repoImplementation, repository);
                }
            }
        }
    }
}
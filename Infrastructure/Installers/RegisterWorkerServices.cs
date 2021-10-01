using Premier.API.Core.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Premier.API.FileUploadDownload.Infrastructure.Installers
{
   internal class RegisterWorkerServices : IServiceRegistration
   {
      public void RegisterAppServices(IServiceCollection services, IConfiguration config)
      {
         //Uncomment to Register Worker Service
      }
   }
}

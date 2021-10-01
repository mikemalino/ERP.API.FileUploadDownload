using Premier.API.Core.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Premier.API.Core.Services;

namespace Premier.API.FileUploadDownload.Infrastructure.Installers
{
   internal class RegisterExternalAPICalls : IServiceRegistration
   {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ExternalAPICallService>();
        }

   
   }
}

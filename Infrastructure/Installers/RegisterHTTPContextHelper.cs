using Premier.API.Core.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Premier.API.Core.Util;

namespace Premier.API.FileUploadDownload.Infrastructure.Installers
{
   internal class RegisterHTTPContextHelper : IServiceRegistration
   {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<iHTTPContextHelper, HTTPContextHelper>();
        }
   }
}

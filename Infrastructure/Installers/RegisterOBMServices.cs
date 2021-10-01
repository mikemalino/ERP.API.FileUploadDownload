using Premier.API.Core.Contracts;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Premier.API.Core.Services;
using Premier.API.Core.MessageQueue;

using RabbitMQ.Client;

namespace Premier.API.FileUploadDownload.Infrastructure.Installers
{
	internal class RegisterOBMServices : IServiceRegistration
	{
		public void RegisterAppServices(IServiceCollection services, IConfiguration config)
		{
//			services.AddScoped(typeof(IOBMRequest<,>), typeof(OBMRequest<,>));
		}
	}
}

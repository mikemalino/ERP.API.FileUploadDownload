using Premier.API.Core.Contracts;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Premier.API.FileUploadDownload.Services;
using System;

namespace Premier.API.FileUploadDownload.Infrastructure.Installers
{
	internal class RegisterContractMappings : IServiceRegistration
	{
		public void RegisterAppServices(IServiceCollection services, IConfiguration config)
		{
			//Register Interface Mappings for Repositories
			//services.AddTransient<IUserProfileManager, UserProfileManager>();
			//services.AddTransient<IUserRepository, UserRepository>();
			//services.AddTransient<IDataProfileRepository, DataProfileRepository>();
			//services.AddTransient<IDataProfileDetailRepository, DataProfileDetailRepository>();

		}

	}
}

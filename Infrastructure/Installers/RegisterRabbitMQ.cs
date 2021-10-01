using Premier.API.Core.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Premier.API.Core.MessageQueue;

namespace Premier.API.FileUploadDownload.Infrastructure.Installers
{
    internal class RegisterRabbitMQ : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {
            var serviceClientSettingsConfig = config.GetSection("RabbitMq");
            services.Configure<RabbitMQConfig>(serviceClientSettingsConfig);

            var rabbitMQConfig = new RabbitMQConfig();
            config.Bind("RabbitMq", rabbitMQConfig);

            bool.TryParse(config["BaseServiceSettings:UserabbitMq"], out var useRabbitMq);

            if (useRabbitMq)
            {
                services.AddSingleton<IRabbitMQConnectionProvider>(new RabbitMQConnectionProvider(rabbitMQConfig));

                /*
                OBMSettings _obmSettings = new OBMSettings();
                config.Bind("ObmSettings", _obmSettings);
                */

                services.AddSingleton<IPublisher>(x => new Publisher(x.GetService<IRabbitMQConnectionProvider>(),
                    rabbitMQConfig.ExchangeName,
                    rabbitMQConfig.ExchangeType));

                /*
                services.AddSingleton<ISubscriber>(x => new Subscriber(x.GetService<IRabbitMQConnectionProvider>(),
                   "ERPNA_APIExchange",
                   "NotespingCartAPIQueue",
                    new string[] 
                        { 
                            "NotespingCart.Added",
                            "NotespingCartLine.*"
                        },
                   ExchangeType.Topic));

                services.AddHostedService<RabbitMQSubscriber>();
                                */

            }
        }
    }
}

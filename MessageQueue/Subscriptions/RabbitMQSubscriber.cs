using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Premier.API.Core.MessageQueue;
using Premier.API.Core.Services;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Premier.API.FileUploadDownload.MessageQueue.Subscriptions
{
    public class RabbitMQSubscriber : BackgroundService
    {
        private readonly ISubscriber _subscriber;
        private readonly ExternalAPICallService _externalAPICallService;
        private readonly string _obmAPIURL = string.Empty;

        IConfiguration _config;

        public RabbitMQSubscriber(ISubscriber subscriber, ExternalAPICallService externalAPICallService, IConfiguration config)
        {
            _subscriber = subscriber;
            _externalAPICallService = externalAPICallService;
            _config = config;

            _obmAPIURL = config["ObmSettings:ObmEndPoint"];
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _subscriber.SubscribeAsync(SubscribeAsync);
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            await Task.CompletedTask;
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
        }

        private async Task<bool> SubscribeAsync(string message, string exchange, string routingKey, IDictionary<string, object> header)
        {
            string customerID = string.Empty;
            string userID = string.Empty;
            string messageGroupID = string.Empty;

            if (header.ContainsKey("CustomerID"))
            {
                customerID = Encoding.UTF8.GetString((byte[])header["CustomerID"]);
            }

            if (header.ContainsKey("UserID"))
            {
                userID = Encoding.UTF8.GetString((byte[])header["UserID"]);
            }

            if (header.ContainsKey("MessageGroupID"))
            {
                messageGroupID = Encoding.UTF8.GetString((byte[])header["MessageGroupID"]);
            }

            return true;
        }
    }
}

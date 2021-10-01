using Premier.API.Core.Contracts;

using Premier.API.Core.Infrastructure.Configs;
using Premier.API.Core.Infrastructure.Handlers;
using Premier.API.Core.Services;

using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace Premier.API.FileUploadDownload.Infrastructure.Installers
{
    internal class RegisterApiResources
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {

            var policyConfigs = new HttpClientPolConfig();
            config.Bind("HttpClientPolicies", policyConfigs);

            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(policyConfigs.RetryTimeoutInSeconds));

            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(r => r.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(policyConfigs.RetryCount, _ => TimeSpan.FromMilliseconds(policyConfigs.RetryDelayInMs));

            var circuitBreakerPolicy = HttpPolicyExtensions
               .HandleTransientHttpError()
               .CircuitBreakerAsync(policyConfigs.MaxAttemptBeforeBreak, TimeSpan.FromSeconds(policyConfigs.BreakDurationInSeconds));

            var noOpPolicy = Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>();

        }
    }
}



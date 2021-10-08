using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Reflection;

using Premier.API.Core.Infrastructure.Extensions;

using Serilog;
using System;

using Premier.API.FileUploadDownload.Data.Entity;

namespace Premier.API.FileUploadDownload
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Init Serilog configuration
            var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.logs.json")
              .Build();

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            try
            {
                Log.Information($"Starting web host: {Assembly.GetExecutingAssembly().FullName}");
                var hostBuilder = CreateHostBuilder(args);
                hostBuilder.Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"Host terminated unexpectedly: {Assembly.GetExecutingAssembly().FullName}");
            }
            finally
            {
                Log.Information($"Stopping web host: {Assembly.GetExecutingAssembly().FullName}");
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(configBuilder =>
                    configBuilder.AddJsonFile("appsettings.Logs.json", true, true)
                )
                .UseSerilog((hostingContext, loggerConfig) =>
                    loggerConfig.ReadFrom.Configuration(hostingContext.Configuration)
                )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .RegisterPremierAPIStartup()
                        /* MLM Added */
                        //.UseIISIntegration()
                        /******/
                        .UseStartup<Startup>();
                });
    }
}

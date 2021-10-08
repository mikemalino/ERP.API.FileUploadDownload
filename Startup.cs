using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

using FluentValidation.AspNetCore;

using Premier.API.Core.Infrastructure.Middleware;

using Premier.API.FileUploadDownload.Data.Contexts;

using Premier.API.Core.Authentication.Configuration;

using Premier.CommonData.ERPNA.Middleware;
using Premier.API.Core.Authentication.Service;
using System.Reflection;
using Premier.API.FileUploadDownload.Infrastructure.Installers;
using Premier.API.FileUploadDownload.Infrastructure.Extensions;
using Premier.API.FileUploadDownload.Infrastructure.AutoMapper;
using Premier.API.FileUploadDownload.Authorization.Policies;

namespace Premier.API.FileUploadDownload
{
    public class Startup
    {
        public IConfiguration Configuration;
        public IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTenantConfig(options =>
            {
                options.UseTenantConfigMediClick(tenantOptions =>
                {
                    tenantOptions.CacheData = Configuration["TenantConfigCache:enabled"] == true.ToString();
                    tenantOptions.ConnectionString = Configuration.GetConnectionString("TenantDBConnectionString");
                }, Configuration, "PremierTenantCache", "TenantConfigCache:redis");
            });

            services.AddDbContext<ApplicationDbContext>();

            //Register services in Installers folder
            services.AddServicesInAssembly(Configuration);

            if (!_env.IsDevelopment())
            {
                RegisterApiResources registerApi = new RegisterApiResources();
                registerApi.RegisterAppServices(services, Configuration);
            }

            services.AddOptions();

            //Register Automapper
            services.AddAutoMapper(typeof(MapProfConfig));

            // This must be added prior to adding controllers
            services.AddCors(options =>
            {
                options.AddPolicy("ERPNACorsPolicy",
                    builder =>
                    {
                        builder
                        // .AllowAnyOrigin()
                        .WithOrigins(Configuration["ApplicationSettings:AllowedURLs"])
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .AllowAnyHeader().WithExposedHeaders("Content-Disposition");
                    });
            });

            //Register MVC/Web API, NewtonsoftJson and add FluentValidation Support
            services.AddControllers()
                    .AddNewtonsoftJson(ops => { ops.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; })
                    .AddFluentValidation(fv => {
                        fv.AutomaticValidationEnabled = true;
                        fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                    });


            // Only for testing purposes
            if (Configuration["Jwt:DevMode"] == true.ToString())
                services.AddSingleton<ITestTokenService, TestTokenService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearerConfiguration(Configuration);


            //            services.AddAuthorization();

            /*
            // Just an example of adding authorization
            services.AddAuthorization(options =>
            {
                var scopes = new[] {
                    "read:billing_settings",
                    "update:billing_settings",
                    "read:customers",
                    "read:files"
                };

                Array.ForEach(scopes, scope =>
                  options.AddPolicy(scope,
                    policy => policy.Requirements.Add(
                      new ScopeRequirement(Configuration["Jwt:Issuer"], scope)
                    )
                  )
                );
            });*/

            services.AddSingleton<IAuthorizationHandler, RequireScopeHandler>();

            services.AddCommonData(options =>
            {
                options.UseERPNACommonData(dataOptions =>
                {
                    dataOptions.EnableLogging = true;
                    dataOptions.EnableSensitiveDataLogging = true;
                    dataOptions.UseConnectionString = false;
                    dataOptions.CacheData = true;
                    dataOptions.CacheLogging = true;
                    dataOptions.TenantConnectionStringTemplate = Configuration["TenantDataOptions:TenantConnectionStringTemplate"];
                }, Configuration, "ERPNACommonDataCache", "ERPNACommonData");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsePremierMiddleware(env, Configuration);

            //Enable CORS
            app.UseCors("ERPNACorsPolicy");


            //Adds authenticaton middleware to the pipeline so authentication will be performed automatically on each request to host
            app.UseAuthentication();

            //Adds authorization middleware to the pipeline to make sure the Api endpoint cannot be accessed by anonymous clients
            app.UseAuthorization();

            app.UseERPNACommonData();

            //            app.UseMiddleware<JwtMiddleware>();


            app.UseDeveloperExceptionPage();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
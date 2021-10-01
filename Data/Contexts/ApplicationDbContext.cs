using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Premier.API.Core.Data.Contexts;
using Premier.API.Core.Util;


using Premier.API.Core.MessageQueue;
using Premier.API.Core.Authentication.Helpers;
using Premier.API.FileUploadDownload.Data.Interceptors;
using Premier.API.FileUploadDownload.Data.Entity;
using Premier.CommonData.Core;

#nullable disable

namespace Premier.API.FileUploadDownload.Data.Contexts
{
    public partial class ApplicationDbContext : PremierDBContext
    {
        protected readonly ILoggerFactory _loggerFactory;
        protected readonly IOptions<TenantDataOptions> _tenantDataOptions;
        protected readonly IPublisher _publisher;

        // Sets the current users dataprofile
        protected string _dataProfile => _HTTPContextHelper.HttpContext().User.GetUserDataProfile();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<TenantDataOptions> tenantDataOptions, ILoggerFactory loggerFactory, iHTTPContextHelper HTTPContextHelper, IPublisher publisher = null) : base(options, HTTPContextHelper)
        {
            _tenantDataOptions = tenantDataOptions;
            _loggerFactory = loggerFactory;
            _publisher = publisher;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Get customer from the context that was set by the middleware.
            string userId = _HTTPContextHelper.HttpContext().User.GetId();
            string tenantServerName = _HTTPContextHelper.HttpContext().User.GetTenantServerName();
            string tenantDBName = _HTTPContextHelper.HttpContext().User.GetTenantDBName();
            string tenantCode = _HTTPContextHelper.HttpContext().User.GetTenantCode();

            string appDBConnectionString = string.Empty;

            if (tenantDBName != null && tenantServerName != null)
            {
                appDBConnectionString = string.Format(_tenantDataOptions.Value.TenantConnectionStringTemplate, tenantServerName, tenantDBName);

                optionsBuilder.EnableSensitiveDataLogging(_tenantDataOptions.Value.EnableSensitiveDataLogging);

                optionsBuilder.UseSqlServer(appDBConnectionString);
                optionsBuilder.UseLoggerFactory(_loggerFactory);

                if (_publisher != null)
                    optionsBuilder.AddInterceptors(new PublishToQueueInteceptor(_publisher, tenantCode, userId));
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Query filters
            // - These filters will apply to every query made on the entity specified in the generic <>
            // - _dataProfile is set from a claimsprinciple extension
            //modelBuilder.Entity<vBuyFromLocRestrictedList>().HasQueryFilter(u => u.DataProfile == _dataProfile);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

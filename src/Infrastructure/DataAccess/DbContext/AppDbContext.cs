// ReSharper disable IdentifierTypo

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Domain.Entities.Fn;
using Domain.Entities.Sp;
using Domain.Entities.Tables;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace $safeprojectname$.DataAccess.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private IWebHostEnvironment HostingEnvironment { get; }
        public Microsoft.EntityFrameworkCore.DbContext Instance => this;
        private bool _disposed;

        // Tables
        public virtual DbSet<Orders> Orders { get; set; }

        // Functions
        public IQueryable<FnSimpleDataFromDb> Fn_SimpleDatafromDb(int appCategory, int appType) => FromExpression(() => Fn_SimpleDatafromDb(appCategory, appType));

        // Store Procedures
        public virtual DbSet<SpComplexDataFromDb> SpComplexDataFromDb { get; set; }

        public AppDbContext(IWebHostEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IWebHostEnvironment hostingEnvironment)
            : base(options)
        {
            HostingEnvironment = hostingEnvironment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var env = HostingEnvironment.EnvironmentName;

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"appsettings.{env}.json", optional: true)
                    .Build();
                var connectionString = configuration.GetConnectionString("Data:SqlServerConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasAnnotation("ProductVersion", "1.0.1-servicing-10062");

            // Tables
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //  CustomQuery
            modelBuilder.Entity(typeof(FnSimpleDataFromDb)).HasNoKey();
            modelBuilder.Entity(typeof(SpComplexDataFromDb)).HasNoKey();

            // Custom Funtions
            modelBuilder.HasDbFunction(() => Fn_SimpleDatafromDb(default, default));

            base.OnModelCreating(modelBuilder);
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing) Instance.Dispose();
            _disposed = true;
        }
    }


}

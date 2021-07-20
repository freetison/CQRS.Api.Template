using System.Linq;
using Domain.Model.Settings.EnvironmentSettings;
using Domain.Services;
using $safeprojectname$.DataAccess.DbContext;
using $safeprojectname$.Services.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace $safeprojectname$.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<EnvironmentSettings>(configuration.GetSection(EnvironmentSettings.Section));
            var sp = services.BuildServiceProvider();
            var apiSettings = sp.GetService<IOptions<EnvironmentSettings>>()?.Value;
            string connectionString = apiSettings?.Data.FirstOrDefault(x => x.Key == "FiterConnectionString")?.Value;

            // Register al DB Cnn
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString ?? string.Empty, b =>
                    b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            // Data Services
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}

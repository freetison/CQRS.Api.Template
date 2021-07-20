using Domain.Model.Settings.AppSettings;
using Domain.Model.Settings.AppSettings.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace $safeprojectname$.DependencyInjection
{
    public static class AppSettingsConfigure
    {
        public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationSettings>(configuration.GetSection("ApplicationSettings"));
            services.AddSingleton(sp => (IApplicationSettings)sp.GetRequiredService<IOptions<ApplicationSettings>>().Value);
            return services;
        }

    }
}

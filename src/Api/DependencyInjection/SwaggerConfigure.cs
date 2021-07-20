using System;
using Domain.Model.Settings.AppSettings;
using Domain.Model.Settings.AppSettings.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace $safeprojectname$.DependencyInjection
{
    public static class SwaggerConfigure
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            ApplicationSettings settings = new ApplicationSettings();
            configuration.GetSection("ApplicationSettings").Bind(settings);

            services.AddSwaggerGen();
            return services;
        }

        private static OpenApiInfo CreateInfoForApiVersion(IApplicationSettings settings)
        {
            var info = new OpenApiInfo()
            {
                Title = settings?.App,
                Version = settings?.Version,
                Description = settings?.Description,
                Contact = new OpenApiContact() { Name = settings?.Contact.Name, Email = settings.Contact.Email },
                TermsOfService = new Uri("http://Shareware.com"),
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") },
            };

            return info;
        }
    }
}

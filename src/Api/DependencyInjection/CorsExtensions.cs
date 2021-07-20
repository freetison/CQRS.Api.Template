using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$.DependencyInjection
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddAllowAllCors(this IServiceCollection services)
        {
          services.AddCors(options =>
          {
            options.AddPolicy("AllowAnyOrigin", builder => {
                builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
              });
          });

          return services;
        }

        public static IServiceCollection AddCorsForLocalhost(this IServiceCollection services, int port)
        {

            services.AddCors(options => options.AddPolicy("AllowLocalhost",
                builder => builder
                    .SetIsOriginAllowed(_ => true)
                    .WithOrigins($"https://localhost:{port}/*", $"http://localhost:{port}/*")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()));

            return services;
        }

        public static IServiceCollection AddCordForAzure(this IServiceCollection services)
        {

            services.AddCors(options => {
                options.AddPolicy("AllowAzure",
                    builder => builder
                        .SetIsOriginAllowed(_ => true)
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .WithOrigins("https://*.azurewebsites.net")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            return services;
        }
    }
}

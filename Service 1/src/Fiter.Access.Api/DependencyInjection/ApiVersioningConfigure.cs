using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Api.DependencyInjection
{
  public static class ApiVersioningConfigure
    {
        public static IServiceCollection AddVersioningApi(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion= new ApiVersion(1,0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("version"),
                    new HeaderApiVersionReader("x-version"),
                    new MediaTypeApiVersionReader("version"),
                    new UrlSegmentApiVersionReader()
                    );

            });
            return services;
        }

    }
}

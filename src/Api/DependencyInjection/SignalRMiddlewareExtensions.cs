using $safeprojectname$.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace $safeprojectname$.DependencyInjection
{
  public static class SignalREndpointRouteBuilderExtensions
    {
        public static IApplicationBuilder SignalRConnectionMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseWhen(context => context.Request.Path.Value != null && context.Request.Path.Value.Contains("/negotiate"), applicationBuilder =>
            {
                applicationBuilder.UseMiddleware<ValidateQueryStringMiddleware>();
                applicationBuilder.UseMiddleware<CachingMiddleware>();
            });

            return builder;
        }

    }
}

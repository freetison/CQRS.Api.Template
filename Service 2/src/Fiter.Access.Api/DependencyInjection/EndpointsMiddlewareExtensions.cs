using Api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Api.DependencyInjection
{
  public static class EndpointsMiddlewareExtensions
    {
        public static IApplicationBuilder UseEndpointsNotifyQrMiddlewares(this IApplicationBuilder builder, string pattern)
        {
            builder.UseWhen(context => context.Request.Path.Value != null && context.Request.Path.Value.Contains(pattern), applicationBuilder =>
            {
                applicationBuilder.UseMiddleware<ExternalTurnValidatorMiddleware>();

            });

            return builder;
        }

    }
}



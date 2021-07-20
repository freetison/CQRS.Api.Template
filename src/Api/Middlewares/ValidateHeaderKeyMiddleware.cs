using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ValidateHeaderKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ValidateHeaderKeyMiddleware> _logger;

        public ValidateHeaderKeyMiddleware(RequestDelegate next, ILogger<ValidateHeaderKeyMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            // ESTO NO VA AQUI PERO EL USEWHEN NO QUIERE FUNCIONAR Y SIEMPRE ME TRAE AQUI
            if (httpContext.Request.Path.Value.Contains("/negotiate"))
            {
                var searchFor = new[] { "app-key", "cat-key" };
                var headerKkeys = httpContext.Request.Headers.Keys;

                var hasKey = searchFor.Any() && searchFor.All(key => headerKkeys.Contains(key));

                if (!hasKey)
                {
                    httpContext.Response.StatusCode = 412;
                    await httpContext.Response.WriteAsync("Precondition Failed, header key is missing");
                    _logger.LogInformation($"{httpContext.Request.Host} sent an unformated header wit url {httpContext.Request.QueryString}");
                    return;
                }
            }

            await _next.Invoke(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ValidateHeaderKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseHeaderKeyMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ValidateHeaderKeyMiddleware>();
            return builder;
        }
    }
}

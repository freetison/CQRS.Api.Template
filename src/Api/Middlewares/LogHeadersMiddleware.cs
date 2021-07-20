using System.Threading.Tasks;
using Application.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$.Middlewares
{
    public class LogHeadersMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogHeadersMiddleware> _logger;

        public LogHeadersMiddleware(RequestDelegate next, ILogger<LogHeadersMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation($"----------------------------------------------------");
            _logger.LogInformation($"[Resquest Header]: {context.Request.Headers.ToJson()}");
            _logger.LogInformation($"----------------------------------------------------");

            //RequestHeaders = context.Request.Headers.ToJson();

            await _next.Invoke(context);


            _logger.LogInformation($"----------------------------------------------------");
            _logger.LogInformation($"[Response Header]: {context.Response.Headers.ToJson()}");
            _logger.LogInformation($"----------------------------------------------------");

        }

    }

}

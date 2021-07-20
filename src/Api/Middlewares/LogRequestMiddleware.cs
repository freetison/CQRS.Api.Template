using System;
using System.IO;
using System.Threading.Tasks;
using Application.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$.Middlewares
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogHeadersMiddleware> _logger;

        public LogRequestMiddleware(RequestDelegate next, ILogger<LogHeadersMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var initialBody = context.Request.Body;

            var contentHeader = context.Request.Headers;
            _logger.LogInformation($"{Environment.NewLine}[Resquest Header]: {contentHeader.ToJson()}{ Environment.NewLine}");

            // var contentBody = await context.Request.GetRawBodyStringAsync();
            // context.Request.EnableRewind();
            using (var reader = new StreamReader(context.Request.Body))
            {
                var contentBody = reader.ReadToEnd();
                _logger.LogInformation($"{Environment.NewLine}[Resquest Body]: {contentBody.ToJson()}{ Environment.NewLine}");
                context.Request.Body.Seek(0, SeekOrigin.Begin);

                // Do something else
            }

            // string contentBody = new StreamReader(context.Request.Body).ReadToEnd();
            await _next.Invoke(context);
            // context.Request.Body = initialBody;
        }

    }

}

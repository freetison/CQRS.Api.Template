using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Application.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$.Middlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {

            _logger.LogInformation($"{Environment.NewLine}[Resquest]:{Environment.NewLine}{await FormatRequest(context.Request)}{Environment.NewLine}");
            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context).ConfigureAwait(false);
                _logger.LogInformation($"{Environment.NewLine}[Response Body]:{Environment.NewLine}{await FormatResponse(context.Response)}{Environment.NewLine}");
                await responseBody.CopyToAsync(originalBodyStream).ConfigureAwait(false);
            }

        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            //request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body.Position = 0;

            return $"{request.Headers.ToJson()}{Environment.NewLine}{request.Host}{request.Path}{request.QueryString}{Environment.NewLine}{bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Position = 0;
            //response.Body.Seek(0, SeekOrigin.Begin);
            string bodyAsText = await new StreamReader(response.Body, Encoding.UTF8).ReadToEndAsync().ConfigureAwait(false);
            //var buffer = new byte[Convert.ToInt32(response.ContentLength)];
            //await response.Body.ReadAsync(buffer, 0, buffer.Length);
            //var bodyAsText = Encoding.UTF8.GetString(buffer);

            //response.Body.Seek(0, SeekOrigin.Begin);
            response.Body.Position = 0;


            return $"{response.Headers.ToJson()}{Environment.NewLine}{bodyAsText}";
        }
    }
}

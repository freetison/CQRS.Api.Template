using System;
using System.IO;
using System.Threading.Tasks;
using Application.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Api.Middlewares
{
  public class ResponseBodyLoggingMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger<ResponseBodyLoggingMiddleware> _logger;
    public ResponseBodyLoggingMiddleware(RequestDelegate next, ILogger<ResponseBodyLoggingMiddleware> logger)
    {
      _next = next;
      _logger = logger;
    }


    public async Task Invoke(HttpContext context)
    {
      var originalBodyStream = context.Response.Body;

      try
      {
        // Swap out stream with one that is buffered and suports seeking
        using var memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        // hand over to the next middleware and wait for the call to return
        await _next(context);

        // Read response body from memory stream
        memoryStream.Position = 0;
        var reader = new StreamReader(memoryStream);
        var responseBody = await reader.ReadToEndAsync();

        // Copy body back to so its available to the user agent
        memoryStream.Position = 0;
        await memoryStream.CopyToAsync(originalBodyStream);
        _logger.LogInformation($"{Environment.NewLine}[Response]:{Environment.NewLine}{context.Response.Headers.ToJson()}{Environment.NewLine}{responseBody}");
        // Write response body to App Insights
        //var requestTelemetry = context.Features.Get<RequestTelemetry>();
        //requestTelemetry?.Properties.Add("ResponseBody", responseBody);
      }
      finally
      {
        context.Response.Body = originalBodyStream;
      }
    }
  }
}

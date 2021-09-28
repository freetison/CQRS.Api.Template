

// ReSharper disable IdentifierTypo


using System.Net;
using System.Threading.Tasks;
using Api.Models;
using Application.Extentions;
using Domain.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        private const string DEFAULT_ERROR_MESSAGE = "Something went wrong on server";

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomException ex)
            {
                var error = new ApiError(DEFAULT_ERROR_MESSAGE, ex, _environment.IsDevelopment());

                _logger.LogError($"Something went wrong: {error.ToJson()}");
                await HandleExceptionAsync(httpContext, error);
            }

            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.InternalServerError)
            {
                //code specifically for a WebException InternalServerError
            }
            finally
            {
                //call this if exception occurs or not
                //wc?.Dispose();
            }


        }

        private Task HandleExceptionAsync(HttpContext context, ApiError errors)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //var apiResponse = new ApiResponse<ApiError>().SetFailed(errors).ToJson();
            return context.Response.WriteAsync(text: "");
        }
    }

}

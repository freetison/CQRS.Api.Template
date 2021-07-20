using System;
using $safeprojectname$.Models;
using Application.Extentions;
using Domain.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$.Filters
{
  public sealed class BusinessExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<BusinessExceptionFilter> _logger;
        private const string DEFAULT_ERROR_MESSAGE = "Something went wrong on server";

        public BusinessExceptionFilter(IWebHostEnvironment environment, ILogger<BusinessExceptionFilter> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            if (ex.GetBaseException() is CustomException)
            {
                var error = new ApiError(DEFAULT_ERROR_MESSAGE, ex, _environment.IsDevelopment());

                _logger.LogError($"{DEFAULT_ERROR_MESSAGE}: {error.ToJson()}");

                DetailsResponse<ApiError> resp = DetailsResponse<ApiError>.Failed(error);
                var result = new JsonResult(resp);

                context.Result = result;
                context.Exception = null;
            }
        }
    }
}

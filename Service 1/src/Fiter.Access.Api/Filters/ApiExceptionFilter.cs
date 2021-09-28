using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Filters.FilterExceptionFactory;
using Api.Models;
using Domain.Common;
using Domain.Exceptions;
using Domain.Model.Validations;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Application.Models;

namespace Api.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private AppLog<object> _appLog;
        private readonly GenericFactory<int, IValidationExceptionProcessor> _customExceptionProcesorFactory;
        private ILogger<ApiExceptionFilter> _logger;
        private IWebHostEnvironment _env;
        private IMediator _mediator;


        public ApiExceptionFilter(AppLog<object> appLog, GenericFactory<int, IValidationExceptionProcessor> customExceptionProcesorFactory, ILogger<ApiExceptionFilter> logger, IWebHostEnvironment env, IMediator mediator)
        {
          _appLog = appLog;
          _customExceptionProcesorFactory = customExceptionProcesorFactory;
          _logger = logger;
          _env = env;
          _mediator = mediator;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            List<CustomValidationError> details = new List<CustomValidationError>();
            if (context.Exception.GetType().BaseType == typeof(CustomException))
            {
                var ex = context.Exception as CustomException;
                details = await _customExceptionProcesorFactory.Get(ex.ErrorCode).Process(ex);
            }
            else
            {
                var ex = context.Exception;
                details = new List<CustomValidationError>() { new("500", "System error") };
                //_mediator.Publish(Some_event);
            }



            DetailsResponse<List<CustomValidationError>> resp = DetailsResponse<List<CustomValidationError>>.Failed(details);
            context.Result = new JsonResult(resp);

            await base.OnExceptionAsync(context);
        }

    }
}

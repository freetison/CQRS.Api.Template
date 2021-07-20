using System.Collections.Generic;
using System.Threading.Tasks;
using $safeprojectname$.Filters.FilterExceptionFactory;
using $safeprojectname$.Models;
using Domain.Common;
using Domain.Exceptions;
using Domain.Model.Validations;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Application.Models;

namespace $safeprojectname$.Filters
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
            //ApiError apiError = new ApiError();
            List<CustomValidationError> details = new List<CustomValidationError>();
            if (context.Exception.GetType().BaseType == typeof(CustomException))
            {
                // procesa CustomException
                var ex = context.Exception as CustomException;
                //apiError = await _customExceptionProcesorFactory.Get(ex.ErrorCode).Process(ex);
                details = await _customExceptionProcesorFactory.Get(ex.ErrorCode).Process(ex);
            }
            else
            {
                // Procesa Exception .net
                // Inyectar en cola... publis un logErrorEvent
                var ex = context.Exception;
                details = new List<CustomValidationError>() { new("500", "System error") };
            }


            //_mediator.Publish(new AccessVerifiedEvent(ex.Data, accessResult));
            //_azureTopicSender.SendAsync(accessResult);






            //_azureQueueSender.SendAsync(accessResult);




            //var strategy = new Dictionary<Type, Func<ExceptionContext, (ExceptionContext, ApiError)>>
            //{
            //    { typeof(CustomException), ProcessCustomException },
            //    { typeof(DomainValidationException), ProcessDomainValidationException },
            //    { typeof(ValidationException<AppLog<AccessResult>>), ProcessValidationException },
            //    //{ typeof(AccessValidationException), ProcessAccessValidationException },
            //    { typeof(UnauthorizedAccessException), ProcessUnauthorizedAccessException },
            //}.WithDefaultValue(ProcessUnhandledException);


            //Type exceptionType = context.Exception.GetType();
            //var contexResult = strategy[exceptionType](context);

            ////contexResult.Item1.Result = new JsonResult(contexResult.Item2);


            ////var error = new ApiError(DEFAULT_ERROR_MESSAGE, ex, _environment.IsDevelopment());

            //DetailsResponse<ApiError> resp = DetailsResponse<ApiError>.Failed(apiError.Message);
            DetailsResponse<List<CustomValidationError>> resp = DetailsResponse<List<CustomValidationError>>.Failed(details);
            context.Result = new JsonResult(resp);

            await base.OnExceptionAsync(context);
        }

        //private void RegisterFactoty()
        //{
        //    _genericFactory.Register((int)Constants.ApiExceptionEnum.NotFoundException, () => new ValidationExceptionProcessor());
        //    _genericFactory.Register((int)Constants.ApiExceptionEnum.DomainValidationException, () => new ValidationExceptionProcessor());
        //    _genericFactory.Register((int)Constants.ApiExceptionEnum.AccessValidationException, () => new ValidationExceptionProcessor());
        //    _genericFactory.Register((int)Constants.ApiExceptionEnum.ApiException, () => new ValidationExceptionProcessor());
        //    _genericFactory.Register((int)Constants.ApiExceptionEnum.InternalServerErrorException, () => new ValidationExceptionProcessor());
        //}

        //private (ExceptionContext, ApiError) ProcessValidationException(ExceptionContext exceptionContext)
        //{
        //    var ex = exceptionContext.Exception as AccessValidationException;

        //    ApiError apiError = new ApiError(ex?.Message) { Errors = ex?.Errors };

        //    exceptionContext.Exception = null!;

        //    // Esto va a injectar el log en una Queue
        //    _Logger.LogError($"Application thrown error: {ex.Message}", ex);

        //    var accessResult = AccessResult.Apply(ResponseState.Denied, Partner.Empty(), false, ex.Message);
        //    _mediator.Publish(new AccessVerifiedEvent(ex.Data, accessResult));
        //    //_azureQueueSender.SendAsync(accessResult);



        //    _azureTopicSender.SendAsync(accessResult);


        //    return (exceptionContext, apiError);
        //}

        //private (ExceptionContext, ApiError) ProcessAccessValidationException(ExceptionContext exceptionContext)
        //{
        //    var ex = exceptionContext.Exception as AccessValidationException;

        //    ApiError apiError = new ApiError(ex?.Message) {Errors = ex?.Errors};

        //    exceptionContext.Exception = null!;

        //    // Esto va a injectar el log en una Queue
        //    _Logger.LogError($"Application thrown error: {ex.Message}", ex);

        //    var accessResult = AccessResult.Apply(ResponseState.Denied, Partner.Empty(), false, ex.Message );
        //    _mediator.Publish(new AccessVerifiedEvent(ex.Data, accessResult));
        //    //_azureQueueSender.SendAsync(accessResult);



        //    _azureTopicSender.SendAsync(accessResult);


        //    return (exceptionContext, apiError);
        //}

        //private (ExceptionContext, ApiError) ProcessDomainValidationException(ExceptionContext exceptionContext)
        //{
        //    var ex = exceptionContext.Exception as DomainValidationException;

        //    ApiError apiError = new ApiError(ex?.Message);
        //    apiError.Errors = ex?.Errors;

        //    exceptionContext.Exception = null!;
        //    //exceptionContext.HttpContext.Response.StatusCode = ex.HResult;

        //    // Esto va a injectar el log en una Queue
        //    _Logger.LogError($"Application thrown error: {ex.Message}", ex);

        //    return (exceptionContext, apiError);

        //}

        //private (ExceptionContext, ApiError) ProcessUnhandledException(ExceptionContext exceptionContext)
        //{
        //    // Unhandled errors
        //    var msg = "";
        //    var stack = "";
        //    if (_env.IsDevelopment())
        //    {
        //        msg = exceptionContext.Exception.GetBaseException().Message;
        //        stack = exceptionContext.Exception.StackTrace;
        //    }
        //    else
        //    {
        //        msg = "An unhandled error occurred.";
        //        stack = null;
        //    }

        //    ApiError apiError = new ApiError(msg, stack);
        //    exceptionContext.HttpContext.Response.StatusCode = 500;

        //    // Esto va a injectar el log en una Queue
        //    _Logger.LogError(new EventId(0), exceptionContext.Exception, msg);

        //    return (exceptionContext, apiError);
        //}

        //private (ExceptionContext, ApiError) ProcessUnauthorizedAccessException(ExceptionContext exceptionContext)
        //{
        //    ApiError apiError = new ApiError("Unauthorized Access");
        //    //exceptionContext.HttpContext.Response.StatusCode = 401;

        //    // Esto va a injectar el log en una Queue
        //    _Logger.LogError("Unauthorized Access in Controller Filter.");

        //    return (exceptionContext, apiError);
        //}


        //private (ExceptionContext, ApiError) ProcessCustomException(ExceptionContext exceptionContext)
        //{
        //    // handle explicit 'known' API errors
        //    var ex = exceptionContext.Exception;

        //    ApiError apiError = new ApiError(ex?.Message);
        //    apiError.Errors = null;

        //    exceptionContext.Exception = null!;
        //    //exceptionContext.HttpContext.Response.StatusCode = ex.HResult;

        //    // Esto va a injectar el log en una Queue
        //    _Logger.LogError($"Application thrown error: {ex.Message}", ex);

        //    return (exceptionContext, apiError);
        //}

    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models;
using Domain.Exceptions;
using Domain.Model.Validations;
using MediatR;

namespace $safeprojectname$.Filters.FilterExceptionFactory
{
    public class DetailedValidationExceptionProcessor : IValidationExceptionProcessor
    {
        private readonly AppLog<object> _appLog;
        private readonly IMediator _mediator;

        public DetailedValidationExceptionProcessor(AppLog<object> appLog, IMediator mediator)
        {
            _appLog = appLog;
            _mediator = mediator;
        }

        public async Task<List<CustomValidationError>> Process(CustomException exceptionContext)
        {
            var ex = exceptionContext as DetailedValidationException<object>;
            var accessControl = ex?.Payload;

            //await _mediator.Publish(new AccessVerifiedEvent(accessControl));

            return ex?.Errors;
            //return  new List<CustomValidationError>() { new (ex?.ErrorCode.ToString(), ex?.Message) };
            //return new ApiError(ex?.Message) { Errors = ex?.Errors };
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models;
using Domain.Exceptions;
using Domain.Model.Validations;
using MediatR;

namespace $safeprojectname$.Filters.FilterExceptionFactory
{
    public class ValidationExceptionProcessor : IValidationExceptionProcessor
    {
        //private readonly IAzureTopicSender _azureTopicSender;
        private readonly AppLog<object> _appLog;
        private readonly IMediator _mediator;

        public ValidationExceptionProcessor(AppLog<object> appLog, IMediator mediator)
        {
            _appLog = appLog;
            _mediator = mediator;
        }

        public async Task<List<CustomValidationError>> Process(CustomException exceptionContext)
        {
            var ex = exceptionContext as ValidationException<object>;
            //var accessControl = ex?.Payload;
            //accessControl?.AccessResult.Apply(false, ex.Message);

            //await _mediator.Publish(new AccessVerifiedEvent(accessControl));

            return new List<CustomValidationError>() { new (ex?.ErrorCode.ToString(), ex?.Message) };

    }
    }
}

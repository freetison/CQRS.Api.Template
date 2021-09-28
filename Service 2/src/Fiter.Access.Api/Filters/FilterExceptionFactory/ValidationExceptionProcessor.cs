using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models;
using Domain.Exceptions;
using Domain.Model.Validations;
using MediatR;

namespace Api.Filters.FilterExceptionFactory
{
    public class ValidationExceptionProcessor : IValidationExceptionProcessor
    {
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
            return new List<CustomValidationError>() { new (ex?.ErrorCode.ToString(), ex?.Message) };

    }
    }
}

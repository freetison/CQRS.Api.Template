using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Extentions;
using Domain.Exceptions;
using Domain.Model.Validations;
using FluentValidation;
using MediatR;

namespace Application.Mediator.PipelineBehavior
{
    public class BusinessValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public BusinessValidationPipeline(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var errors = failures.Select(e => new ValidationErrorResult(e.ErrorCode, e.PropertyName, e.ErrorMessage));
                    throw new DomainValidationException(errors.ToJson());
                }
            }
            return await next();

        }
    }
}



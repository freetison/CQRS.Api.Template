using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Model.Validations;

namespace Api.Filters.FilterExceptionFactory
{
    public interface IValidationExceptionProcessor
    {
        Task<List<CustomValidationError>> Process(CustomException exceptionContext);
  }
}

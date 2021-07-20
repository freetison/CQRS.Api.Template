using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Model.Validations;

namespace $safeprojectname$.Filters.FilterExceptionFactory
{
    public interface IValidationExceptionProcessor
    {
        //Task<ApiError> Process(CustomException exceptionContext);
        Task<List<CustomValidationError>> Process(CustomException exceptionContext);
  }
}

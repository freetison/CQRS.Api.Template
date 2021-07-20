using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Model.Validations;

namespace $safeprojectname$.Exceptions
{
    public sealed class DetailedValidationException<T> : CustomException
    {

        private const int ERROR_CODE = (int)Constants.ApiExceptionEnum.DetailedValidationException;

        public override string ExceptionType { get; set; } = "DetailedValidation";
        public override int ErrorCode { get; set; } = ERROR_CODE;
        public override bool IsPublic { get; set; } = true;
        public T Payload;

        public List<CustomValidationError> Errors { get; set; }

        private DetailedValidationException(List<CustomValidationError> errors, T payload) : base(ERROR_CODE, errors.FirstOrDefault()?.Message)
        {
            HResult = ERROR_CODE;
            Payload = payload;
            Errors = errors;
        }


        public static DetailedValidationException<T> Apply(List<CustomValidationError> errors, T payload) => new DetailedValidationException<T>(errors, payload);

    }
}
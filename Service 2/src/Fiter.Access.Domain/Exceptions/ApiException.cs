using System.Collections.Generic;
using Domain.Model.Validations;

namespace Domain.Exceptions
{
    public class ApiException : CustomException
    {
        private const int ERROR_CODE = (int)Constants.ApiExceptionEnum.ApiException;

        public override string ExceptionType { get; set; } = "ApiException";
        public override int ErrorCode { get; set; } = ERROR_CODE;
        public override bool IsPublic { get; set; } = true;

        public List<ValidationError> Errors { get; set; }

        public ApiException() : base(ERROR_CODE, "Api Exception") => HResult = ERROR_CODE;

        public ApiException(string message) : base(ERROR_CODE, message) => HResult = ERROR_CODE;

        public ApiException(string message, List<ValidationError> errors = null) : base(ERROR_CODE, message)
        {
            Errors = errors;
            HResult = ERROR_CODE;
        }
    }

}
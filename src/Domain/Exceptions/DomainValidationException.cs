using System.Collections.Generic;
using $safeprojectname$.Model.Validations;

namespace $safeprojectname$.Exceptions
{
    public class DomainValidationException : CustomException
    {
        private const int ERROR_CODE = (int)Constants.ApiExceptionEnum.DomainValidationException;

        public override string ExceptionType { get; set; } = "DomainValidation";
        public override int ErrorCode { get; set; } = ERROR_CODE;
        public override bool IsPublic { get; set; } = true;


        public List<ValidationError> Errors { get; set; }

        public DomainValidationException() : base(ERROR_CODE, "Bad request on validation") => HResult = ERROR_CODE;

        public DomainValidationException(string message) : base(ERROR_CODE, message) => HResult = ERROR_CODE;

        public DomainValidationException(string message, List<ValidationError> errors = null) : base(ERROR_CODE, message)
        {
            Errors = errors;
            HResult = ErrorCode;
        }

    }
}

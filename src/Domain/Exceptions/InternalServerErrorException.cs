namespace $safeprojectname$.Exceptions
{
    public class InternalServerErrorException : CustomException
    {
        private const int ERROR_CODE = (int)Constants.ApiExceptionEnum.InternalServerErrorException;

        public override string ExceptionType { get; set; } = "InternalServerError";
        public override int ErrorCode { get; set; } = ERROR_CODE;
        public override bool IsPublic { get; set; } = true;

        public InternalServerErrorException() : base(ERROR_CODE, "Internal Server Error") => HResult = ERROR_CODE;

        public InternalServerErrorException(string message) : base(ERROR_CODE, message) => HResult = ERROR_CODE;
    }

}

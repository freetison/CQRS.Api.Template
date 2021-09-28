namespace Domain.Exceptions
{
    public class NotFoundException: CustomException
    {
        private const int ERROR_CODE = (int)Constants.ApiExceptionEnum.NotFoundException;

        public override string ExceptionType { get; set; } = "NotFound";
        public override int ErrorCode { get; set; } = ERROR_CODE;
        public override bool IsPublic { get; set; } = true;

        public NotFoundException() : base(ERROR_CODE, "Not Fount") => HResult = ERROR_CODE;

        public NotFoundException(string message) : base(ERROR_CODE, message) => HResult = ERROR_CODE;

    }

}

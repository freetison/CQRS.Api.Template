namespace $safeprojectname$.Model.Validations
{
    public class ValidationErrorResult
    {
        public string ErrorCode { get; set; }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationErrorResult(string errorCode, string propertyName, string errorMessage)
        {
            ErrorCode = errorCode;
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}

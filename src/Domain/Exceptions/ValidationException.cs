using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Model.Validations;

namespace $safeprojectname$.Exceptions
{
    public sealed class ValidationException<T> : CustomException
    {

        private const int ERROR_CODE = (int)Constants.ApiExceptionEnum.AccessValidationException;

        //public Dictionary<string, string> Errors;

        //var error = new Dictionary<string, string>
        //    {
        //        {"Type", ex.GetType().ToString()},
        //        {"Message", ex.Message},
        //        {"StackTrace", ex.StackTrace}
        //    };

        //    foreach (DictionaryEntry data in ex.Data)
        //error.Add(data.Key.ToString(), data.Value.ToString());

        public override string ExceptionType { get; set; } = "AccessValidation";
        public override int ErrorCode { get; set; } = ERROR_CODE;
        public override bool IsPublic { get; set; } = true;
        public T Payload;

        public List<CustomValidationError> Errors { get; set; }

        private ValidationException(T payload) : base(ERROR_CODE, "Error en Validación de Acceso")
        {
            HResult = ERROR_CODE;
            Payload = payload;
        }

        private ValidationException(string message, T payload) : base(ERROR_CODE, message)
        {
            HResult = ERROR_CODE;
            Payload = payload;
        }

        private ValidationException(List<CustomValidationError> errors, T payload) : base(ERROR_CODE, errors.FirstOrDefault()?.Message)
        {
            HResult = ERROR_CODE;
            Payload = payload;
            Errors = errors;
        }


        public static ValidationException<T> Apply(string message, T payload) => new ValidationException<T>(message, payload);
        public static ValidationException<T> Apply(List<CustomValidationError> errors, T payload) => new ValidationException<T>(errors, payload);
        public static ValidationException<T> Empty(T payload) => new ValidationException<T>(payload);

    }
}
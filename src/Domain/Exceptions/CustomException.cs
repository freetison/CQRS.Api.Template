using System;

namespace $safeprojectname$.Exceptions
{
    public abstract class CustomException : Exception
    {
        public abstract string ExceptionType { get; set; }
        public abstract int ErrorCode { get; set; }
        public abstract bool IsPublic { get; set; }

        protected CustomException() : base() { }

        protected CustomException(int code, string message) : base(message) => base.HResult = code;

        protected CustomException(int code, string message, Exception inner) : base(message, inner) => base.HResult = code;
    }

}

using MediatR;

namespace $safeprojectname$.Mediator.Events
{
    public class AppExceptionEvent : INotification
    {
        public string Error { get; set; }

        public AppExceptionEvent(string error) => Error = error;
    }
}

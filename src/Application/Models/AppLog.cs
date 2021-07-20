using System;

namespace $safeprojectname$.Models
{
    public class AppLog<T> where T : class, new()
    {
        public T PayLoad;

        public string RequestId { get; set; }
        public bool Resultado { get; set; }
        public string AppVersion { get; set; }
        public DateTime Created { get; set; }

        public AppLog(T payLoad, string requestId, bool resultado, string appVersion, DateTime created)
        {
            PayLoad = payLoad;
            RequestId = requestId;
            Resultado = resultado;
            AppVersion = appVersion;
            Created = created;
        }
    }
}
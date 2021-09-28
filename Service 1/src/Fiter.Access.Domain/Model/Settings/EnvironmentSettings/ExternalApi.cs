using System.Collections.Generic;

namespace Domain.Model.Settings.EnvironmentSettings
{
    public class ExternalApi
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public int RequestTimeout { get; set; }
        public List<Parameter> Parameters { get; set; }
        public Credentials Credentials { get; set; }
    }
}
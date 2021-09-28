using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Model.Settings.EnvironmentSettings
{
    public class EnvironmentSettings : IEnvironmentSettings
    {
        public const string Section = "EnvironmentSettings";

        public List<Data> Data { get; set; }
        public List<ExternalApi> ExternalApi { get; set; }
        public ServiceBus ServiceBus { get; set; }
    }
}

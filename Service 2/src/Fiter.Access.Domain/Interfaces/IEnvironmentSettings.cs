using System.Collections.Generic;
using Domain.Model.Settings.EnvironmentSettings;

namespace Domain.Interfaces
{
    public interface IEnvironmentSettings
    {
        public List<Data> Data { get; set; }
        public List<ExternalApi> ExternalApi { get; set; }
    }
}
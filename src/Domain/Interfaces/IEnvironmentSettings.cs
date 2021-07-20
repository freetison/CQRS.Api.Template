using System.Collections.Generic;
using $safeprojectname$.Model.Settings.EnvironmentSettings;

namespace $safeprojectname$.Interfaces
{
    public interface IEnvironmentSettings
    {
        public List<Data> Data { get; set; }
        public List<ExternalApi> ExternalApi { get; set; }
    }
}
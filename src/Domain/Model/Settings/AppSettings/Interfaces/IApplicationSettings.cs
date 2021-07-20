using System.Collections.Generic;

namespace $safeprojectname$.Model.Settings.AppSettings.Interfaces
{
    public interface IApplicationSettings
    {
        string App { get; set; }
        string Version { get; set; }
        string Description { get; set; }
        Contact Contact { get; set; }
        string AllowedHosts { get; set; }
        Ports Ports { get; set; }
        List<BusinessRule> BusinessRules { get; set; }
    }
}
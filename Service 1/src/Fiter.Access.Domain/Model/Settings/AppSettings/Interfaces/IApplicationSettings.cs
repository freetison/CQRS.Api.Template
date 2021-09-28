using System.Collections.Generic;

namespace Domain.Model.Settings.AppSettings.Interfaces
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
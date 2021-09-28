// ReSharper disable IdentifierTypo

using System;
using System.Collections.Generic;
using Domain.Model.Settings.AppSettings.Interfaces;

namespace Domain.Model.Settings.AppSettings {
    public class ApplicationSettings : IApplicationSettings
    {
        public string App { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public Contact Contact { get; set; }
        public string AllowedHosts { get; set; }
        public Ports Ports { get; set; }
        public List<BusinessRule> BusinessRules { get; set; }

        public ApplicationSettings(Contact contact, Ports ports, List<BusinessRule> businessRules)
        {
            App = String.Empty;
            Version = String.Empty;
            Description = String.Empty;
            AllowedHosts = String.Empty;
            Contact = contact as Contact;
            Ports = ports;
            BusinessRules = businessRules;
        }

        public ApplicationSettings()
        {

        }
    }
}

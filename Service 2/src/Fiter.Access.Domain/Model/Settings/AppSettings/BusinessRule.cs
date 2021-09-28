using Domain.Model.Settings.AppSettings.Interfaces;

namespace Domain.Model.Settings.AppSettings
{
    public class BusinessRule : IBusinessRule
    {
        public string Rule { get; set; }
        public string Value { get; set; }

        public BusinessRule()
        {
        }

        public BusinessRule(string rule, string value)
        {
            Rule = rule;
            Value = value;
        }
    }
}

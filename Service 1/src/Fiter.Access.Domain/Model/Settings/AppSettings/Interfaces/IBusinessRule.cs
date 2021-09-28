namespace Domain.Model.Settings.AppSettings.Interfaces
{
    public interface IBusinessRule
    {
        string Rule { get; set; }
        string Value { get; set; }
    }
}
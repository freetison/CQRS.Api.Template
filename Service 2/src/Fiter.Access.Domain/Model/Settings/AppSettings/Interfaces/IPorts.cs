namespace Domain.Model.Settings.AppSettings.Interfaces
{
    public interface IPorts
    {
        int httpListenPort { get; set; }
        int httpsListenPort { get; set; }
    }
}
namespace $safeprojectname$.Model.Settings.EnvironmentSettings
{
    public class AccessApi
    {
        public string ApiBaseUrl { get; set; }
        public string EndPoint { get; set; }
        public int RequestTimeout { get; set; }
        public Parameters Parameters { get; set; }
        public Credentials Credentials { get; set; }
    }
}
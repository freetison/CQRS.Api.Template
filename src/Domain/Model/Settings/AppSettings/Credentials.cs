using $safeprojectname$.Model.Settings.AppSettings.Interfaces;

namespace $safeprojectname$.Model.Settings.AppSettings
{

    public class Credentials: ICredentials
    {
        public string User { get; set; }
        public string Pass { get; set; }

        public Credentials()
        {
        }

        public Credentials(string user, string pass)
        {
            User = user;
            Pass = pass;
        }
    }
}

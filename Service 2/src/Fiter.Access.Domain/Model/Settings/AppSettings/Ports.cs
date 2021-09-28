using Domain.Model.Settings.AppSettings.Interfaces;

namespace Domain.Model.Settings.AppSettings
{

    public class Ports : IPorts
    {
        public int httpListenPort { get; set; }
        public int httpsListenPort { get; set; }

        public Ports()
        {
        }

        public Ports(int httpListenPort, int httpsListenPort)
        {
            this.httpListenPort = httpListenPort;
            this.httpsListenPort = httpsListenPort;
        }
    }
}
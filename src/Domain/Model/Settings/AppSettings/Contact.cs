using $safeprojectname$.Model.Settings.AppSettings.Interfaces;

namespace $safeprojectname$.Model.Settings.AppSettings
{
    public class Contact : IContact
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Contact()
        {
        }

        public Contact(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}

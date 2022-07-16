using System.ComponentModel;

namespace Task3WindowsService
{
    /// <summary>
    /// Service installer
    /// </summary>
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}

using ClienteAPI.Pages;

namespace ClienteAPI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GestionPlatosPage),typeof(GestionPlatosPage));
        }
    }
}

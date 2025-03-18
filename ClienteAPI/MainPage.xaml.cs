using ClienteAPI.ConexionDatos;
using System.Diagnostics;

namespace ClienteAPI
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestConexionDatos _restConexionDatos;
        public MainPage(IRestConexionDatos restConexionDatos)
        {
            InitializeComponent();
            _restConexionDatos = restConexionDatos;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            coleccionPlatosView.ItemsSource = await _restConexionDatos.GetPlatosAsync();
        }

        // Métodos evento
        async void OnAddPlatoAsync(object sender, EventArgs e) { 
            // Al darle clic esperamos ir a otra page donde ingresar datos de Plato
            Debug.WriteLine("[EVENTO] Botón AddPlato clickeado.");
        }
        async void OnElementoCambiado(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("[EVENTO] Botón ElementoCambiado clickeado.");
        }
    }

}

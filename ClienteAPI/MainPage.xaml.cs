using ClienteAPI.ConexionDatos;
using ClienteAPI.Models;
using ClienteAPI.Pages;
using System.Diagnostics;

namespace ClienteAPI.Pages
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
            // coleccionPlatosView.ItemsSource = await _restConexionDatos.GetPlatosAsync();
            var platos = await _restConexionDatos.GetPlatosAsync();
            Debug.WriteLine($"*********> Platos obtenidos: {platos.Count}");  // Verificar la cantidad de platos obtenidos.

            // Ordenar aleatoriamente
            var random = new Random();
            platos = platos.OrderBy(x => random.Next()).ToList();


            coleccionPlatosView.ItemsSource = platos;

            if (platos.Count == 0)
            {
                Debug.WriteLine("No se encontraron platos.");
            }
        }

        // Métodos evento
        async void OnAddPlatoAsync(object sender, EventArgs e) {
            // Al darle clic esperamos ir a otra page donde ingresar datos de Plato
            var param = new Dictionary<string, object>() {
                { nameof(Plato), new Plato()}
            };
            await Shell.Current.GoToAsync(nameof(GestionPlatosPage), param);
            Debug.WriteLine("[EVENTO] Botón AddPlato clickeado.");
        }
        async void OnElementoCambiado(object sender, SelectionChangedEventArgs e)
        {
            var param = new Dictionary<string, object>() {
                { nameof(Plato), e.CurrentSelection.FirstOrDefault() as Plato}
            };
            await Shell.Current.GoToAsync(nameof(GestionPlatosPage), param);
            Debug.WriteLine("[EVENTO] Botón ElementoCambiado clickeado.");
        }
    }

}

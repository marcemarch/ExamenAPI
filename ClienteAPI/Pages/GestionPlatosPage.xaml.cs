using ClienteAPI.ConexionDatos;
using ClienteAPI.Models;

namespace ClienteAPI.Pages;
[QueryProperty(nameof(plato),"Plato")]
public partial class GestionPlatosPage : ContentPage
{
	private readonly IRestConexionDatos restConexionDatos;
	private Plato _plato;
	public Plato plato {
		get => _plato;
		set {
			_esNuevo = esNuevo(value);
			_plato = value;
			OnPropertyChanged();
		}
	}
	private bool _esNuevo;
	public GestionPlatosPage(IRestConexionDatos restConexionDatos)
	{
		InitializeComponent();
		this.restConexionDatos = restConexionDatos;
		BindingContext = this;
	}
	bool esNuevo(Plato plato) {
		/*if (plato.Id == 0)
			return true;
		return false;
		*/
		return plato.Id == 0;
	}

	async void OnCancelClic(Object sender, EventArgs e) { 
		await Shell.Current.GoToAsync("..");
    }
	async void OnSaveClic(Object sender, EventArgs e)
	{ 
		if(_esNuevo)
            await restConexionDatos.AddPlatoAsync(plato);
        else
            await restConexionDatos.UpdatePlatoAsync(plato);
        await Shell.Current.GoToAsync("..");
    }
	async void OnDeleteClic(Object sender, EventArgs e) { 
		await restConexionDatos.DeletePlatoAsync(plato.Id);
        await Shell.Current.GoToAsync("..");
    }
}
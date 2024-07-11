using avillarroelS6.Modelos;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace avillarroelS6.Views;

public partial class vEstudiante : ContentPage
{
    private const string Url = "http://192.168.200.7/semana6/estudiantes.php";
    /*private const string Url = "http://192.168.17.40/semana6/estudiantes.php";*/
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Modelos.Estudiante> est;

    public vEstudiante()
	{
		InitializeComponent();
		mostrar();
	}

	public async void mostrar()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Modelos.Estudiante> mostrar = JsonConvert.DeserializeObject<List<Modelos.Estudiante>>(content);
		est = new ObservableCollection<Modelos.Estudiante>(mostrar);
        listaEstudiantes.ItemsSource = est;
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Views.vAgregar());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new ActEliminar(objEstudiante));
    }

}
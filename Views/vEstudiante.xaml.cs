using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace avillarroelS6.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://192.168.17.40/semana6/estudiantes.php";
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
}
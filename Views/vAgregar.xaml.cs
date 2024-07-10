using System.Net;

namespace avillarroelS6.Views;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre",txtNombre .Text);
			parametros.Add("apellido",txtApellido .Text);
			parametros.Add("edad",txtEdad.Text);

			cliente.UploadValues("http://192.168.17.40/semana6/estudiantes.php", "POST", parametros);
			Navigation.PushAsync(new vEstudiante());
		}	
		catch (Exception ex)
		{
			DisplayAlert("Alerta", ex.Message, "OK");
			
		}
    }

}
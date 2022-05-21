using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetodoswWS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertar : ContentPage
    {
        Datos dtos = new Datos();
        WebClient webClient = new WebClient();
        public Insertar()
        {
            InitializeComponent();
        }

        public Insertar(Datos datos)
        
        {
            InitializeComponent();
            dtos = datos;
            txtCodigo.Text = dtos.codigo.ToString();
            txtNombre.Text = dtos.nombre.ToString();
            txtApellido.Text = dtos.apellido.ToString();
            txtEdad.Text = dtos.edad.ToString();

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (dtos != null)
            {
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                webClient.UploadValues("http://192.168.100.1/moviles/post.php", "PUT", parametros);
                DisplayAlert("Exito", "Datos ingresados correctamente", "Cerrar");
            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (dtos != null)
            {
                webClient.UploadValues("http://192.168.100.1/moviles/post.php?id=" + dtos.codigo.ToString(), "DELETE", new NameValueCollection());
                DisplayAlert("Exito", "Datos ingresados correctamente", "Cerrar");
            }

        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                webClient.UploadValues("http://192.168.100.1/moviles/post.php", "POST", parametros);
                DisplayAlert("Exito", "Datos ingresados correctamente", "Cerrar");
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}
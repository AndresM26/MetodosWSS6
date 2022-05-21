using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetodoswWS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consulta : ContentPage
    {
        private const string Url = "http://192.168.100.1/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Datos> _post;
        public Consulta()
        {
            InitializeComponent();
        }

        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<Datos> post = JsonConvert.DeserializeObject<List<Datos>>(content);
                _post = new ObservableCollection<Datos>(post);
                lsvView.ItemsSource = _post;
            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
        private async void lsvView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            Datos club = (Datos)lv.SelectedItem;
            await Navigation.PushAsync(new Insertar(club));
        }

        private void btnGet_Clicked(object sender, EventArgs e)
        {

        }
    }
}

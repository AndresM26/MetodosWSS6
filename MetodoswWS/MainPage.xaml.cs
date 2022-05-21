using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace MetodoswWS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        
        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Consulta());
        }

        private async void btnInsertar_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Insertar());
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace semana6
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.0.109/clientes/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<semana6.Ws.AccesoDatos> _post;
        public MainPage()
        {
            InitializeComponent();
            get();
        }

       public async void get()
        {

            var content = await client.GetStringAsync(Url);
            List<semana6.Ws.AccesoDatos> posts = JsonConvert.DeserializeObject<List<semana6.Ws.AccesoDatos>>(content);
            _post = new ObservableCollection<Ws.AccesoDatos>(posts);
            MyListView.ItemsSource = _post;
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VentanaIngreso());
        }
    }
}

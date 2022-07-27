//using MuayThaiApi.Entity.Security;
using CarMuayTahiSeguimiento.Tools;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarMuayTahiSeguimiento.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vwPagos : ContentPage
    {
        //List<_Afiliado> pagosList;
        public vwPagos()
        {
            InitializeComponent();

            RestHelper prueba = new RestHelper(
                @"http://ingbame.somee.com/api",
                "Security",
                HttpMethod.Get
            );
            prueba.RestRequest();
            //if (pagosList != null)
            //    lstPagos.ItemsSource = pagosList;
        }
    }
}
using CarMuayTahiSeguimiento.Models;
using CarMuayTahiSeguimiento.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarMuayTahiSeguimiento
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        List<FlyoutItemPage> MenuItems;
        public Master()
        {
            InitializeComponent();

            var asm = typeof(Master).Assembly.GetName();
            MenuItems = new List<FlyoutItemPage>
            {
                new FlyoutItemPage{ Title = "Inicio", IconSource="icon_about.png", TargetPage = Type.GetType($"CarMuayTahiSeguimiento.Detail, {asm}")},
                new FlyoutItemPage{ Title = "Registrar pago", IconSource="icon_feed.png", TargetPage =Type.GetType($"CarMuayTahiSeguimiento.Views.RegistroDePago, {asm}")},
                new FlyoutItemPage{ Title = "Pagos", IconSource="icon_feed.png", TargetPage = Type.GetType($"CarMuayTahiSeguimiento.Views.vwPagos, {asm}")},
                new FlyoutItemPage{ Title = "Historial de clases", IconSource="icon_feed.png", TargetPage = Type.GetType($"CarMuayTahiSeguimiento.Views.HistorialClasesTomadas, {asm}")}
            };
            if (MenuItems != null)
                lvMenu.ItemsSource = MenuItems;
        }
    }
}
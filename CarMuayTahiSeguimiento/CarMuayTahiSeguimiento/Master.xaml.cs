using CarMuayTahiSeguimiento.Models;
using CarMuayTahiSeguimiento.Tools;
using CarMuayTahiSeguimiento.Tools.Enums;
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
            MenuItems = new List<FlyoutItemPage>();

            RestHelper menuLst = new RestHelper(
                @"http://ingbame.somee.com/api",
                "App",
                HttpMethodsEnum.Get,
                "1"
            );           

            List<MenuItemModel> response = menuLst.RestRequest<List<MenuItemModel>>().Result;

            if (!menuLst.Error)
                if (response != null || response.Count <= 0)
                {
                    foreach (var item in response)
                    {
                        MenuItems.Add(new FlyoutItemPage { Title = item.Title, IconSource = item.IconSource, TargetPage = Type.GetType($"{item.TargetPage}, {asm}") });
                    }
                }
                else
                    DisplayAlert("Error", "Menú no se ha cargado correctamente", "Ok");
            else
                DisplayAlert("Error", menuLst.Message, "Ok");

            if (MenuItems.Count > 0)
                lvMenu.ItemsSource = MenuItems;
        }
    }
}
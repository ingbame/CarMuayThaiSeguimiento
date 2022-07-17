using CarMuayTahiSeguimiento.Services;
using CarMuayTahiSeguimiento.SQLite;
using CarMuayTahiSeguimiento.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarMuayTahiSeguimiento
{
    public partial class App : Application
    {
        private static Database database;
        private static Database Database
        {
            get
            {
                if (database == null)
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MuayThaiDb.db3"));
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new PantallaInicio();
            
            //var prueba2 = new CarMuayTahiSeguimiento.SQLite.DbModels.PagosPor15Clases()
            //{
            //    FechaPago = DateTime.Now,
            //    MetodoPagoId = 1,                
            //};
            //var ins1 = Database.SavePagosPor15ClasesAsync(prueba2);
            //var res = Database.GetPagosPor15ClasesAsync();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

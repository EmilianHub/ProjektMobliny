using ProjektMobliny.Services;
using ProjektMobliny.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace ProjektMobliny
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        private async void Button_Clicked(Object sender, EventArgs e)
        {
            try
            {
                var lokacja = await Geolocation.GetLastKnownLocationAsync();
                if(lokacja == null)
                {
                    lokacja = await Geolocation.GetLocationAsync(new GeolocationRequest 
                    { 
                        DesiredAccuracy = GeolocationAccuracy.Medium, 
                        Timeout = TimeSpan.FromSeconds(45) 
                    }); 
                }

            }
            catch(Exception ew)
            {
                 Console.WriteLine($"Coś poszło nie tak {ew.Message}");
            }
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

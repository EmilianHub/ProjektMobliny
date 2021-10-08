using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektMobliny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class geolokacja : ContentPage
    {
        public geolokacja()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(Object sender, EventArgs e)
        {
            try
            {
                var lokacja = await Geolocation.GetLastKnownLocationAsync();
                if (lokacja == null)
                {
                    lokacja = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(5)
                    });
                }
                if (lokacja.Equals(null))
                {
                    LabelLocation.Text = $"No GPS";
                }
                else LabelLocation.Text = $"Twoja pozycja: {lokacja.Latitude} {lokacja.Longitude}";

            }
            catch (Exception ew)
            {
                Console.WriteLine($"Coś poszło nie tak {ew.Message}");
            }
        }
    }
}
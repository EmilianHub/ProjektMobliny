using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;
using ProjektMobliny.ViewModels;
using MvvmHelpers;
using ProjektMobliny.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProjektMobliny.Services;
using System.Linq;
using System.Globalization;

namespace ProjektMobliny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Geolokacja : ContentPage
    {
        CultureInfo culture = new CultureInfo("en-US");
        public Exception exception;
        public List<StacjeMaps> Pins { get; set; }
        public Position Userposition;
        public Position Stationposition;
        public Location Location;
        public DistanceOp distance;
        public Duration czas;
        public List<adres> Orlen {get; set; }
        public List<adres>BP  {get; set; }
        public List<adres> Shell  {get; set; }
        public List<adres> lotos  {get; set; }
        public List<adres> circle  {get; set; }
        public List<adres> mpk_Stacja_paliw  {get; set; }
        public List<adres> Tank_System  {get; set; }
        public List<adres> As24  {get; set; }
        public List<adres> Olma  {get; set; }
        public List<adres> Petrodom { get; set; }
        public List<adres> moya { get; set; }
        public List<adres> Huzar { get; set; }
        public List<adres> Grod { get; set; }
        public string LatOrigin { get; set; }
        public string LngOrigin { get; set; }
        public Geolokacja()
        {
            InitializeComponent();
            Lokalizacja();
            Mapy.MoveToRegion(MapSpan.FromCenterAndRadius(Userposition, Distance.FromMeters(5000)));
            Pins = new List<StacjeMaps>()
            {
                new StacjeMaps(){Nazwa = "Orlen", Latitude = 49.75646382302269, Longitude=20.74837194079188},
                new StacjeMaps(){Nazwa = "Lotos", Latitude = 49.63320891434197, Longitude=20.692252999627673},
                new StacjeMaps(){Nazwa = "BP", Latitude = 49.63968479822199, Longitude=20.695299988939016}
            };
            Orlen = new List<adres>()
            {
                new adres(){marka = "Orlen", dlugosc = 49.633415051101466, szerokosc = 20.692490947954923},
                new adres(){marka = "Orlen", dlugosc = 49.6241406364093, szerokosc =  20.71987533236763},
                new adres(){marka = "Orlen", dlugosc = 49.6303852643307, szerokosc = 20.669800369325607},
            };
            BP = new List<adres>()
            {
                new adres(){marka = "Bp", dlugosc = 49.62423615118385, szerokosc = 20.72060006455892 },
                new adres(){marka = "Bp", dlugosc = 49.65936092676387, szerokosc = 20.68875145953169 },
                new adres(){marka = "Bp", dlugosc = 49.57435622412546, szerokosc = 20.6633509269948 },
            };
            Shell = new List<adres>()
            {
                new adres(){marka = "Shell", dlugosc = 49.616735055909174, szerokosc = 20.717138548076825 },
                new adres(){marka = "Shell", dlugosc = 49.605377946975736, szerokosc = 20.72540247117391 },
            };
            lotos = new List<adres>()
            {
                new adres(){ marka = "lotos", dlugosc = 49.603670249284114, szerokosc = 20.69555575422503 },
                new adres(){ marka = "lotos", dlugosc = 49.58473063690698, szerokosc = 20.672315357679853 },
                new adres(){ marka = "lotos", dlugosc = 49.60363594550532, szerokosc = 20.695435492371757 },
            };
            circle = new List<adres>()
            {
                new adres(){marka= "circle", dlugosc = 49.62032656738285, szerokosc = 20.70702341725663 },
            };
            mpk_Stacja_paliw = new List<adres>()
            {
                new adres(){marka = "Mpk Stacja Paliw", dlugosc = 49.602867688379185 , szerokosc = 20.70034896800667},
            };

            Tank_System = new List<adres>()
            {
                new adres() { marka = "Tank System", dlugosc = 49.60578244326132, szerokosc = 20.69177638849593},
            };
            As24 = new List<adres>()
            {
                new adres(){marka = "AS24", dlugosc = 49.607610971784084, szerokosc =20.712353626756286}, 
            };
            Olma = new List<adres>()
            {
                new adres(){marka = "Olma", dlugosc = 49.633306855994746, szerokosc =20.696227042099707},
            };
            moya = new List<adres>()
            {
                new adres(){marka = "Moya", dlugosc = 49.621463588725, szerokosc =20.7431985846677}, 
            };
            Petrodom = new List<adres>()
            {
                new adres(){marka = "Petrodom", dlugosc = 49.60228881187323, szerokosc =20.723381211413756},
            };
            Huzar= new List<adres>()
            {
                new adres(){marka = "Huzar", dlugosc = 49.54875935285061, szerokosc =20.585378750298112},
            };
            Grod = new List<adres>()
            {
                new adres(){marka = "Grod", dlugosc = 49.66961247774395, szerokosc =20.651308096074235},
            };


            Stationposition = new Position(Pins[1].Latitude, Pins[1].Longitude);
            LoadPins();
            Trasa();
        }
        public async void Lokalizacja()
        {
            try
            {
                var lokacja = await Geolocation.GetLastKnownLocationAsync();

                LatOrigin = Convert.ToString(lokacja.Latitude, culture);
                LngOrigin = Convert.ToString(lokacja.Longitude, culture);

                Userposition = new Position(lokacja.Latitude, lokacja.Longitude);
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
                    await DisplayAlert("Error", "Proszę włączyć GPS", "OK");
                }
            }
            catch (Exception ew)
            {
                await DisplayAlert("Error", $"{ew.Message}", "OK");
            }
        }
        public void LoadPins()
        {
            try
            {
                foreach (var item in Pins)
                {
                    var pin = new Pin()
                    {
                        Type = PinType.Place,
                        Label = item.Nazwa,
                        Position = new Position(item.Latitude, item.Longitude),
                    };
                    Mapy.Pins.Add(pin);
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Error", $"{e.Message}", "OK");
            }
        }

        internal async Task<List<Position>> LoadRoute()
        {
            var googleDirection = await ApiService.ServiceClientInstance.GetDirection(LatOrigin, LngOrigin, $"49.63320891434197", $"20.692252999627673");
            if (googleDirection.Routes != null && googleDirection.Routes.Count > 0)
            {
                var positions = Enumerable.ToList(PolylineHelper.Decode(googleDirection.Routes.First().OverviewPolyline.Points));
                distance = googleDirection.Routes[0].Legs[0].Distance;
                czas = googleDirection.Routes[0].Legs[0].Duration;
                return positions;
                
            }
            else
            {
                await DisplayAlert("Error", $"Cos poszło nie tak", "OK");
                return null;
            }
        }

        private async void Trasa()
        {
            var content = await LoadRoute();
            var polyline = new Xamarin.Forms.GoogleMaps.Polyline();
            polyline.StrokeColor = Color.Blue;
            polyline.StrokeWidth = 10;
            try
            {
                foreach (var linia in content)
                {
                    polyline.Positions.Add(linia);
                }
                Mapy.Polylines.Add(polyline);
                Footer.Text = $"{distance} • {czas}";
            }
            catch (Exception e)
            {
                await DisplayAlert("Error", $"{e.Message}", "OK");
            }
        }
    }
}

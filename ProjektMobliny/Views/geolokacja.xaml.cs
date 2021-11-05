﻿using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
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
        public Position position;
        public Location Location;
        public string LatOrigin { get; set; }
        public string LngOrigin { get; set; }
        public Geolokacja()
        {
            InitializeComponent();
            Lokalizacja();
            Mapy.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMeters(5000)));
            Pins = new List<StacjeMaps>()
            {
                new StacjeMaps(){Nazwa = "Orlen", Latitude = 49.75646382302269, Longitude=20.74837194079188},
                new StacjeMaps(){Nazwa = "Lotos", Latitude = 49.63320891434197, Longitude=20.692252999627673},
                new StacjeMaps(){Nazwa = "BP", Latitude = 49.63968479822199, Longitude=20.695299988939016}
            };
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
                
                position = new Position(lokacja.Latitude, lokacja.Longitude);
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
            var polyline = new Xamarin.Forms.Maps.Polyline();
            polyline.StrokeColor = Color.Blue;
            polyline.StrokeWidth = 10;
            try
            {
                foreach(var linia in content)
                {
                    polyline.Geopath.Add(linia);
                }
                Mapy.MapElements.Add(polyline);              
            }
            catch(Exception e)
            {
                await DisplayAlert("Error", $"{e.Message}", "OK");
            }
        }
    }
}
using ProjektMobliny.Models;
using ProjektMobliny.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjektMobliny.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        
        //public Command OpenGeolokacje { get; }
        public MainViewModel()
        {
            //OpenGeolokacje = new Command(OnOpenGelokacje);        
        }
        
        private async void OnOpenGelokacje(object ob) => await Shell.Current.GoToAsync($"//{nameof(geolokacja)}");
    }
}
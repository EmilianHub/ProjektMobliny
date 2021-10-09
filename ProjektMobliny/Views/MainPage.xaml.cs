using ProjektMobliny.Models;
using ProjektMobliny.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektMobliny.Views
{
    public partial class MainPage : ContentPage
    {              
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }  
    }
}
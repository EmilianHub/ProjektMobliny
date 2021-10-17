using ProjektMobliny.Models;
using ProjektMobliny.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektMobliny.Views
{
    public partial class NewPowiadomieniaPage : ContentPage
    {
        public Item Item { get; set; }

        public NewPowiadomieniaPage()
        {
            InitializeComponent();
            BindingContext = new NewPowiadomieniaViewModel();
        }
    }
}
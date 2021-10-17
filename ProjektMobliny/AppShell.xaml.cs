using ProjektMobliny.ViewModels;
using ProjektMobliny.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ProjektMobliny
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PowiadomieniaDetailPage), typeof(PowiadomieniaDetailPage));
            Routing.RegisterRoute(nameof(NewPowiadomieniaPage), typeof(NewPowiadomieniaPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}

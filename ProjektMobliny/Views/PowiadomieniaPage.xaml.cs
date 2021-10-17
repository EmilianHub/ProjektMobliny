using ProjektMobliny.Models;
using ProjektMobliny.ViewModels;
using ProjektMobliny.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektMobliny.Views
{
    public partial class PowiadomieniaPage : ContentPage
    {
        PowiadomieniaViewModel _viewModel;

        public PowiadomieniaPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PowiadomieniaViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
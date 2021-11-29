using ProjektMobliny.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektMobliny.Views
{
    public partial class KalkulatorPage : ContentPage
    {
        public KalkulatorPage()
        {
            InitializeComponent();
            BindingContext = new KalkulatorViewModel();
        }
    }
}
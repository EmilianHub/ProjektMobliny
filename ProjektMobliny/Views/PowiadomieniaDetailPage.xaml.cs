using ProjektMobliny.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProjektMobliny.Views
{
    public partial class PowiadomieniaDetailPage : ContentPage
    {
        public PowiadomieniaDetailPage()
        {
            InitializeComponent();
            BindingContext = new PowiadomieniaDetailViewModel();
        }
    }
}
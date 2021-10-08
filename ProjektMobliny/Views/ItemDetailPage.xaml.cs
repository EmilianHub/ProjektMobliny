using ProjektMobliny.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProjektMobliny.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
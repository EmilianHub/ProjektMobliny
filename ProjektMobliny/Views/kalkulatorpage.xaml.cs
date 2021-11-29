using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektMobliny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class kalkulator : ContentPage
    {
      

        public kalkulator()
        {
            InitializeComponent();

            BindingContext = new kalkulator();
            

           
            
        }

       
    }
}

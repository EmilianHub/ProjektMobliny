using ProjektMobliny.Motywy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektMobliny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UstawieniaPage : ContentPage
    {
        public UstawieniaPage()
        {
            InitializeComponent();
            
            switch (Ustawienia.Motyw)
            {
                case 0:
                    ButtonLight.IsChecked = true;
                    break;
                case 1:
                    ButtonDark.IsChecked = true;
                    break;
            }
        }

        bool ustawione;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ustawione = true;
        }
        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!ustawione)
                return;
            if (!e.Value)
                return;
            var val = (sender as RadioButton)?.Content as string;
            if(string.IsNullOrWhiteSpace(val))
                return;

            switch(val)
            {
                case "Light":
                    Ustawienia.Motyw = 0;
                    break;
                case "Dark":
                    Ustawienia.Motyw = 1;
                    break;
            }
            UstawMotyw.WczytajMotyw();
        }
    }
}
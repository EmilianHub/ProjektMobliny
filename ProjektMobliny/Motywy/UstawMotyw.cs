using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjektMobliny.Motywy
{
    public class UstawMotyw
    {
        public static void WczytajMotyw()
        {
            switch(Ustawienia.Motyw)
            {
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ProjektMobliny.Motywy
{
    public static class Ustawienia
    {
        //Light = 0, Dark =1;
        public const int motyw = 0;
        public static int Motyw
        {
            get => Preferences.Get(nameof(Motyw), motyw);
            set => Preferences.Set(nameof(Motyw), value);
        }
    }
}

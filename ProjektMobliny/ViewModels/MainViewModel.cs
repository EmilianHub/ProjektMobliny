using MvvmHelpers;
using ProjektMobliny.Models;
using ProjektMobliny.Views;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ProjektMobliny.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Stacje>Stacja { get; set; }
        public MainViewModel()
        {

            Stacja = new ObservableRangeCollection<Stacje>() {
                  new Stacje() { Id = 1, Nazwa = "Orlen", Cena95 = 5.9, Cena98 = 5.7, CenaON = 5.99, CenaLPG = 3.34, adres = "Tarnowska"},
                  new Stacje() { Id = 2, Nazwa = "Shell", Cena95 = 5.71 , Cena98 = 5.98 , CenaON = 5.49, CenaLPG = 2.66 , adres = "Aleje\nPiłsudskiego"},
                  new Stacje() { Id = 3, Nazwa = "Bp", Cena95 = 5.79    , Cena98 = 5.89 , CenaON = 5.35, CenaLPG = 3.49 , adres ="Prażmowskiego\n9" },
                  new Stacje() { Id = 4, Nazwa = "Lotos", Cena95 = 5.85 , Cena98 = 5.94 , CenaON = 5.71, CenaLPG = 2.94 , adres =" Zielona\n55"},
                  new Stacje() { Id = 5, Nazwa = "Circle", Cena95 = 5.82    , Cena98 = 6.12 , CenaON = 5.72, CenaLPG = 2.94 , adres = "Kilińskiego\n64"},
                  new Stacje() { Id = 6, Nazwa = "Orlen", Cena95 = 6.00, Cena98 = 6.1  , CenaON = 3.2  , CenaLPG = 6.15, adres ="Lwowska\n140" },
                  new Stacje() { Id = 7, Nazwa = "Shell", Cena95 = 5.9  , Cena98 = 5.95 , CenaON = 6.15, CenaLPG = 3.2 , adres ="Gorzkowska\n32" },
                  new Stacje() { Id = 8, Nazwa = "BP", Cena95 = 5.85    , Cena98 = 5.94 , CenaON = 6.12, CenaLPG = 3.12, adres =" Tarnowska\n177" },
                  new Stacje() { Id = 9, Nazwa = "Lotos", Cena95 = 5.99 , Cena98 = 5.88 , CenaON = 5.82 , CenaLPG = 3.23, adres = "Węgierska\n152"},
                  new Stacje() { Id = 10, Nazwa = "Orlen", Cena95 = 6, Cena98 = 6.14, CenaON = 6.2, CenaLPG = 3.21, adres = "Krakowska"},
                  new Stacje() { Id = 11, Nazwa = "Bp", Cena95 = 5.91, Cena98 = 5.92, CenaON = 6.12, CenaLPG = 3.14, adres = "Węgierska\n303"},
                  new Stacje() { Id = 12, Nazwa = "Lotos", Cena95 = 5.89, Cena98 = 5.91, CenaON = 5.97, CenaLPG = 2.95, adres ="Nawojowska\n165" },
                  new Stacje() { Id = 13, Nazwa = "Tank System", Cena95 = 5.5, Cena98 = 0.00, CenaON = 5.3, CenaLPG = 0.00, adres ="Węgierska\n8/10" },
                  new Stacje() { Id = 14, Nazwa = "Mpk\nStacja Paliw", Cena95 = 0.00, Cena98 = 0.00, CenaON = 5.96, CenaLPG = 0.00, adres = "Szczepanowskiego"},
                  new Stacje() { Id = 15, Nazwa = "AS24", Cena95 = 0.00, Cena98 = 0.00, CenaON = 4.9, CenaLPG = 0.00, adres ="Rafała\nKrajewskiego 27" },
                  new Stacje() { Id = 16, Nazwa = "OLMA", Cena95 = 5.3  , Cena98 = 5.4  , CenaON = 5.2, CenaLPG = 0.00, adres = "Dojazdowa\n7"},
                  new Stacje() { Id = 17, Nazwa = "Petrodom", Cena95 = 5.7, Cena98 = 0.00, CenaON = 5.6, CenaLPG = 0.00, adres ="Wiśniowieckiego\n123c" },
                  new Stacje() { Id = 18, Nazwa = "Moya", Cena95 = 5.8, Cena98 = 5.7, CenaON = 5.5, CenaLPG = 3.3, adres = "Lwowska\n236"},
                  new Stacje() { Id = 19, Nazwa = "Huzar", Cena95 = 5.69, Cena98 = 5.99, CenaON = 5.73, CenaLPG = 3.25, adres = "Gołkowice\nDolne 181"},
                  new Stacje() { Id = 20, Nazwa = "Grod", Cena95 = 5.7, Cena98 = 6.00, CenaON = 5.8, CenaLPG = 3.35, adres = "Marcinkowicka\n33-393"},
                   
                   
            };           
        }               
    }
}
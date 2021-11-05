using MvvmHelpers;
using ProjektMobliny.Models;
using ProjektMobliny.Views;
using Xamarin.Forms;

namespace ProjektMobliny.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Stacje>Stacja { get; set; }
        public MainViewModel()
        {

            Stacja = new ObservableRangeCollection<Stacje>() {
                new Stacje() { Id = 1, Nazwa = "Orlen", Cena95 = 6.10, Cena98 = 6.25, CenaON = 4, CenaLPG = 3.12 },
                new Stacje() { Id = 2, Nazwa = "Shell", Cena95 = 6.05, Cena98 = 6.25, CenaON = 4.10, CenaLPG = 3.12 },
                new Stacje() { Id = 3, Nazwa = "BP", Cena95 = 6.14, Cena98 = 6.21, CenaON = 4.08, CenaLPG = 3.12 },
                new Stacje() { Id = 4, Nazwa = "Lotos", Cena95 = 6.12, Cena98 = 6.35, CenaON = 4.90, CenaLPG = 3.12 },
                new Stacje() { Id = 5, Nazwa = "Circle", Cena95 = 6.11, Cena98 = 6.22, CenaON = 4.23, CenaLPG = 3.12 },
            };
        }

        Stacje Wybranastacja;
        public Stacje WybranastacjaCommand
        {
            get => Wybranastacja;
            set
            {
                Wybranastacja = value;
                OnPropertyChanged(nameof(Wybranastacja));
            }
        }
        private async void OnOpenGelokacje(object ob) => await Shell.Current.GoToAsync($"//{nameof(Geolokacja)}");
    }
}
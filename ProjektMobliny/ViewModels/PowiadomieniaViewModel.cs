using Plugin.LocalNotification;
using ProjektMobliny.Models;
using ProjektMobliny.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjektMobliny.ViewModels
{
    public class PowiadomieniaViewModel : BaseViewModel
    {       
        private Item _selectedItem;
        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> DeleteItemCommand { get; }
        public Command<Item> ItemTapped { get; }
        private readonly List<Item> Wiadomosci; //do usunięcia potem
        private readonly Random rnd = new Random();
        private static int i = 1;
        public PowiadomieniaViewModel()
        {
            Title = "Powiadomienia";        
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            DeleteItemCommand = new Command<Item>(OnDelete);

            Wiadomosci = new List<Item>()
            {
                new Item { Text = "Rząd bierze się za ceny paliwa", Description="Branża mówi o sporym ryzuku - nafta"},
                new Item { Text = "Na mapie Polski wyróżnia sie Wielkopolska", Description="Podwyżki detalicznych cen paliw zdają się nie mieć końca, a do widoku ponad 6 złotych za litr benzyny"},
                new Item { Text = "Warszawa, wyciek paliwa z tira", Description="Do zdarzenia doszło po godzinie 4, na Czerniakowskiej, na wysokości Krajowego Rejestru Karnego."},
            };
        }      

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewPowiadomieniaPage));
        }     

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PowiadomieniaDetailPage)}?{nameof(PowiadomieniaDetailViewModel.ItemId)}={item.Id}");
        }

        private async void OnDelete(Item item)
        {
            if (item == null)
                return;
            await DataStore.DeleteItemAsync(item.Id);
            await ExecuteLoadItemsCommand();
        }

        public async void Powiadomienia()
          {           
            int los = rnd.Next(2);
            var powiadomienie = new NotificationRequest
            {
                BadgeNumber = 1,
                Title = "Tanie Paliwo",
                Subtitle = $"{DateTime.Now}",
                Description = Wiadomosci[los].Text,
                ReturningData = Wiadomosci[los].Description,
                NotificationId = i++,
                Schedule =
                {
                    NotifyTime = DateTime.Now.AddSeconds(3) // Do testów wywołanie powiadomienie bo 3 sekundach
                },                
            };
            try
            {
                Item newItem = new Item()
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = powiadomienie.Description,
                    Description = powiadomienie.ReturningData,
                    Czas = $"{DateTime.Now}",
                };

                await DataStore.AddItemAsync(newItem);
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }                      
            await NotificationCenter.Current.Show(powiadomienie);
            await ExecuteLoadItemsCommand();
        }
    }
}
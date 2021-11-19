using Plugin.LocalNotification;
using ProjektMobliny.Models;
using ProjektMobliny.Views;
using System;
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

        public PowiadomieniaViewModel()
        {
            Title = "Powiadomienia";        
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            DeleteItemCommand = new Command<Item>(OnDelete);
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
        }

        public async void Powiadomienia()
          {
            var powiadomienie = new NotificationRequest
            {
                BadgeNumber = 1,
                Title = "Tanie Paliwo",
                Subtitle = $"{DateTime.Now}",
                Description = "Zmiany w świecie paliwa",
                ReturningData = "Od dziś ważna zmiana na wszyskich stacjach...",
                NotificationId = 1,
                Silent = true,
                Schedule =
                {
                    NotifyTime = DateTime.Now.AddSeconds(5) // Do testów wywołanie powiadomienie bo 5 sekundach
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
        }
    }
}
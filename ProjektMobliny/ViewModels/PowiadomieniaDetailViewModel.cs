using ProjektMobliny.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjektMobliny.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class PowiadomieniaDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private string czas;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string Czas
        {
            get => czas;
            set => SetProperty(ref czas, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                Czas = item.Czas;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}

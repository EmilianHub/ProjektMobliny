using ProjektMobliny.Models;
using ProjektMobliny.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektMobliny.Views
{
    public partial class MainPage : ContentPage
    {
        private Picker wybor;
        private Button przycisk;
        public Entry wejscie;
        
        public MainPage()
        {
            InitializeComponent();
            List<Stacje> Stacja = new List<Stacje>();
            Stacja.Add(new Stacje() { Id = 1, Nazwa = "Orlen" });
            Stacja.Add(new Stacje() { Id = 2, Nazwa = "Shell" });
            Stacja.Add(new Stacje() { Id = 3, Nazwa = "BP" });
            Stacja.Add(new Stacje() { Id = 4, Nazwa = "Lotos" });
            Stacja.Add(new Stacje() { Id = 5, Nazwa = "Circle" });
            StackLayout stackLayout = new StackLayout();         
                wybor = new Picker();
                wybor.Title = "Wybierz stacje paliw";
                wybor.ItemsSource = Stacja;
                stackLayout.Children.Add(wybor);
                przycisk = new Button();
                przycisk.Text = "Szukaj stacji";
                przycisk.Clicked += Przycisk_Clicked;
                stackLayout.Children.Add(przycisk);

                wejscie = new Entry();
                wejscie.Keyboard = Keyboard.Text;
                wejscie.Placeholder = "Wybrana stacja";
                stackLayout.Children.Add(wejscie);
        }

        public void Przycisk_Clicked(object sender, EventArgs e)
        {
            wejscie.Text = wybor.SelectedItem.ToString();
        }
    }
}
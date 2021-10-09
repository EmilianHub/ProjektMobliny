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
        public MainPage()
        {
            InitializeComponent();
            List<Stacje> Stacja = new List<Stacje>();
            Stacja.Add(new Stacje() { Id = 1, Nazwa = "Orlen" });
            Stacja.Add(new Stacje() { Id = 2, Nazwa = "Shell" });
            Stacja.Add(new Stacje() { Id = 3, Nazwa = "BP" });
            Stacja.Add(new Stacje() { Id = 4, Nazwa = "Lotos" });
            Stacja.Add(new Stacje() { Id = 5, Nazwa = "Circle" });
            wybor.Title = "Wybierz stacje";
            wybor.ItemsSource = Stacja;
            Glowna.Children.Add(wybor);
            przycisk.Text = "Szukaj stacji";
            przycisk.Clicked += Przycisk_Clicked;
            Glowna.Children.Add(przycisk);
            wejscie.Keyboard = Keyboard.Text;
            wejscie.Placeholder = "Wybrana stacja";
            Glowna.Children.Add(wejscie);

        }

        public void Przycisk_Clicked(object sender, EventArgs e)
        {
            wejscie.Text = wybor.SelectedItem.ToString();
        }
    }
}
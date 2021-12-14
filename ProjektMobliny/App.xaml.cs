using ProjektMobliny.Data;
using ProjektMobliny.Services;
using ProjektMobliny.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektMobliny
{
    public partial class App : Application
    {
        private static  PaliwoDatabase paliwoDatabase;
        public static PaliwoDatabase PaliwoDatabase
        {
            
         get
            {
                if (paliwoDatabase == null)
                {
                    paliwoDatabase = new PaliwoDatabase();

                }
                return paliwoDatabase;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

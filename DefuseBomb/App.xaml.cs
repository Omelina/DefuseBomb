using DefuseBomb.Services;
using DefuseBomb.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefuseBomb
{
    public partial class App : Application
    {

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

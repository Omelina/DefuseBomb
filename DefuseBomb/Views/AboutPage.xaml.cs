using DefuseBomb.Views;
using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefuseBomb.Views
{
    public partial class AboutPage : ContentPage
    {

        public AboutPage()
        {
            InitializeComponent();
            Title = "Let's play";
            bomb = new Random().Next(1, 4).ToString();
            scores = 0;
        }

        public async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text == bomb)
            {
                await App.Current.MainPage.DisplayAlert("Bomb Exploted", "GAME OVER", "Retry");
                bomb = new Random().Next(1, 4).ToString();
                scores = 0;
            }
            else
            {
                scores += 1;
                await DisplayAlert("Bomb Defused!", "Scores: " + scores, "Continue");
                bomb = new Random().Next(1, 4).ToString();
            }
        }

        private string bomb;
        private int scores;
    }
}
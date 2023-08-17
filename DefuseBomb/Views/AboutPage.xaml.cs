using DefuseBomb.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefuseBomb.Views
{
    public partial class AboutPage : ContentPage
    {

        List<int> top3 = new List<int> { 0, 0, 0 };
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
                //,"\n","Segundo: ", top3[1], "\n","Tercero: ", top3[0]
                guardar(scores);
                string mensaje = "Top 3 scores:\n" +
                                 $"Primero: {top3[0]}\n" +
                                 $"Segundo: {top3[1]}\n" +
                                 $"Tercero: {top3[2]}";
                await App.Current.MainPage.DisplayAlert("Bomb Exploted ",mensaje, "Retry");
                bomb = new Random().Next(1, 4).ToString();
                scores = 0;
            }
            else
            {
                scores += 3;
                await DisplayAlert("Bomb Defused!", "Scores: " + scores, "Continue");
                bomb = new Random().Next(1, 4).ToString();
            }
        }


        private string bomb;
        private int scores;
        public void guardar(int numero)
        {
            int numero1 = top3[0];
            int numero2 = top3[1];
            int numero3 = top3[2];
            if (numero >= numero1)
            {
                if(numero2 != 0)
                {
                    top3[2] = top3[1];
                }
                
            top3[1] = top3[0];
            top3[0] = numero;
            return;
            }
            else if (numero >= numero2)
            {
                if (numero3 != 0)
                {
                    top3[2] = top3[1];
                }
                
                top3[1] = numero;
                return;
            }
            else if (numero >= numero3)
            {
                top3[2] = numero;
                return;
            }
            else
            {
                return;
            }
        }


    }
}
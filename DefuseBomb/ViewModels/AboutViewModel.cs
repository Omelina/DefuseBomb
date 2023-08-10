using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DefuseBomb.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        public AboutViewModel()
        {
            Title = "Let's play";
            //ButtonClickedCommand = new Command(ButtonClicked);
            bomb = new Random().Next(1, 4).ToString();
        }

        

        //public ICommand ButtonClickedCommand { get; }

        private string bomb;
    }
}
using DefuseBomb.Models;
using DefuseBomb.ViewModels;
using DefuseBomb.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefuseBomb.Views
{
    public partial class RankPage : ContentPage
    {

        // Define la propiedad y el tipo con el mismo nivel de acceso.
        public List<RankingItem> RankingList { get; set; }

        public RankPage()
        {
            InitializeComponent();

            // Crea una lista de ejemplo para mostrar en la tabla de ranking.
            RankingList = new List<RankingItem>
            {
                new RankingItem { PlayerName = "Player 1", Points = 100 },
                new RankingItem { PlayerName = "Player 2", Points = 90 },
                new RankingItem { PlayerName = "Player 3", Points = 85 },
                // Agrega más elementos según sea necesario...
            };

            // Establece el contexto de datos para el enlace de datos.
            BindingContext = this;
        }


    }
}
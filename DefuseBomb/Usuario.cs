using System;
using System.Collections.Generic;
using System.Text;

namespace DefuseBomb
{
    class Usuario
    {
        public string userName { get; set; }
        public string Password { get; set; }
        public string email { get; set; }

        public static List<Usuario> ListaUsuarios { get; set; } = new List<Usuario>
        {
            new Usuario {userName = "anthony", Password = "123456", email = "anthony.1960@hotmail.es"},
            new Usuario {userName = "oky", Password = "123456", email = "oky.1960@hotmail.es"},
            new Usuario {userName = "carlos", Password = "123456", email = "carlos.1960@hotmail.es"}


        };
    }
}

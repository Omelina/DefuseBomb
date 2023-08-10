using DefuseBomb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefuseBomb.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private List<Usuario> listaUsuarios;
        private int intentosFallidos = 0;
        private bool cuentaBloqueada = false;
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

            listaUsuarios = Usuario.ListaUsuarios;


        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if (cuentaBloqueada)
            {
                await DisplayAlert("Cuenta bloqueada", "Tu cuenta ha sido bloqueada por demasiados intentos fallidos. Por favor, contacta al administrador.", "OK");
                return;
            }
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            bool login = VerificarCredenciales(username, password);

            if (login)
            {

                await Navigation.PushAsync(new AboutPage());
            }
            else
            {
                intentosFallidos++;

                if (intentosFallidos >= 3)
                {
                    cuentaBloqueada = true;
                    await DisplayAlert("Cuenta bloqueada", "Has excedido el número máximo de intentos fallidos. Tu cuenta ha sido bloqueada. Por favor, contacta al administrador.", "OK");
                }
                else
                {
                    int intentosRestantes = 3 - intentosFallidos;
                    await DisplayAlert("Error", $"Invalid username or password. Te quedan {intentosRestantes} intentos.", "OK");
                }
                //await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private bool VerificarCredenciales(string nombreUsuario, string password)
        {
            // Buscar el usuario en la lista por el nombre de usuario
            var usuario = listaUsuarios.Find(u => u.userName == nombreUsuario);

            // Verificar si se encontró el usuario y si coincide la contraseña
            return usuario != null && usuario.Password == password;
        }
    }
}
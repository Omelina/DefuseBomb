using DefuseBomb.Models;
using DefuseBomb.ViewModels;
using DefuseBomb.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefuseBomb.Views
{
    public partial class RegisterPage : ContentPage
    {

        public RegisterPage()
        {
            InitializeComponent();

        }

        private void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;

            // Aquí agregas la lógica para procesar los datos ingresados en el formulario de registro.
            // Por ejemplo, puedes realizar validaciones y llamar a un servicio para registrar al usuario.

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                DisplayAlert("Error", "Please fill in all fields", "OK");
            }
            else if (!ValidarPassword(password)){

                DisplayAlert("Error", "La password debe de tener minimo una mayuscula, un numero y mas de 6 caracteres", "OK");
            }
            else if (password != confirmPassword)
            {
                DisplayAlert("Error", "Passwords do not match", "OK");
            }
            else
            {
                Usuario newUser = new Usuario
                {
                    email = email,
                    userName = username,
                    Password = password
                };
                Usuario.ListaUsuarios.Add(newUser);
                // Registro exitoso, puedes mostrar un mensaje o navegar a otra página.
                DisplayAlert("Success", "Registration successful", "OK");
                // Puedes navegar a la página de inicio de sesión u otra página después del registro exitoso.
                Navigation.PushAsync(new LoginPage());
            }

        }
        private bool ValidarPassword(string password)
        {
            // Utilizar expresiones regulares para verificar cada requisito
            bool tieneNumero = Regex.IsMatch(password, @"\d");
            bool tieneMayuscula = Regex.IsMatch(password, "[A-Z]");
            bool longitudValida = password.Length > 6;

            // Verificar que cumple con todos los requisitos
            return tieneNumero && tieneMayuscula && longitudValida;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TickNager.Helper;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class LoginWindowViewModel
    {
        //Datos ingrados por el usuario.
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public LoginWindowViewModel() 
        {
        }

        /// <summary>
        /// Permite iniciar sesión si los datos introducidos son correctos, de lo contrario muestra un mensaje de error.
        /// </summary>
        public void iniciarSesion(Window window)
        {
            bool existeUsuario = UsuarioRepository.VerificarUsuario(Correo, Contrasena);

            if (!existeUsuario)
            {
                MessageBox.Show("Correo o contraseña incorrectos. Por favor, inténtelo de nuevo.", "Error de inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                window.Show();
            }
        }
    }
}

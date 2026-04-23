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
        public bool iniciarSesion()
        {
            Usuario usuario = UsuarioRepository.ObtenerUsuarioPorCredenciales(Correo, Contrasena);

            if (usuario == null)
            {
                MessageBox.Show("Correo o contraseña incorrectos. Por favor, inténtelo de nuevo.", "Error de inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                SesionUsuario.UsuarioActual = usuario;
                return true;
            }
        }
    }
}

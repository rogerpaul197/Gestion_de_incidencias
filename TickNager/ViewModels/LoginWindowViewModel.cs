using System.Windows;
using TickNager.Helper;
using TickNager.Models;
using TickNager.Repositories;
using TickNager.Views.Windows;

namespace TickNager.ViewModels
{
    public class LoginWindowViewModel
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public bool InicioCorrecto { get; set; }

        public LoginWindowViewModel()
        {
        }

        public void IniciarSesion()
        {
            string contrasenaHasheada = HashPasswordHelper.HashPassword(Contrasena);

            Usuario usuario = UsuarioRepository.ObtenerUsuarioCredenciales(Correo, contrasenaHasheada);

            if (usuario == null)
            {
                InicioCorrecto = false;
                MessageBox.Show("Correo o contraseña incorrectos. Por favor, inténtelo de nuevo.", 
                "Error de inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SesionUsuarioHelper.UsuarioActual = usuario;
            InicioCorrecto = true;

            DashboardWindow ventana = new DashboardWindow();
            ventana.Show();
        }

        public void MostrarAyuda()
        {
            InformacionWindow ventanaInformacion = new InformacionWindow();
            ventanaInformacion.Show();
        }
    }
}
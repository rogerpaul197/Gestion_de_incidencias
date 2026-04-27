using System.Windows;
using TickNager.Helper;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class VistaAjustesViewModel
    {
        public string NuevaContrasena { get; set; }
        public string ConfirmarContrasena { get; set; }

        public string NombreCompleto
        {
            get { return SesionUsuario.UsuarioActual.NombreCompleto; }
        }

        public string Correo
        {
            get { return SesionUsuario.UsuarioActual.CorreoUsuario; }
        }

        public string Rol
        {
            get { return SesionUsuario.UsuarioActual.RolUsuario; }
        }

        public string Departamento
        {
            get { return SesionUsuario.UsuarioActual.Departamento; }
        }

        public void EditarPerfil()
        {
            MessageBox.Show("La edición del perfil la haremos después.");
        }

        public void CambiarContrasena()
        {
            if (string.IsNullOrWhiteSpace(NuevaContrasena) || string.IsNullOrWhiteSpace(ConfirmarContrasena))
            {
                MessageBox.Show("Completa los campos de contraseña.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (NuevaContrasena != ConfirmarContrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string contrasenaHash = HashPasswordHelper.HashPassword(NuevaContrasena);

            UsuarioRepository.CambiarContrasena(SesionUsuario.UsuarioActual.Id, contrasenaHash);

            MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            NuevaContrasena = "";
            ConfirmarContrasena = "";
        }
    }
}
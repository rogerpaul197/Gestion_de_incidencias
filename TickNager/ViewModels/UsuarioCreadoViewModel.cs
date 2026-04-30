using System.Windows;
using TickNager.Helper;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class UsuarioCreadoViewModel
    {
        public bool usuarioEliminado { get; set; }

        public void VerPerfil(object obj)
        {
            Usuario usuario = obj as Usuario;

            if (usuario == null)
            {
                return;
            }

            DashboardViewModel.obj.mostrarVistaPerfilUsuario(usuario);
        }

        public void CambiarRol(object obj)
        {
            Usuario usuario = obj as Usuario;

            if (usuario == null)
            {
                return;
            }

            DashboardViewModel.obj.mostrarFormularioCambiarRolUsuario(usuario);
        }

        public void EliminarUsuario(object obj)
        {
            usuarioEliminado = false;

            Usuario usuario = obj as Usuario;

            if (usuario == null)
            {
                return;
            }

            if (usuario.Id == SesionUsuarioHelper.UsuarioActual.Id)
            {
                MessageBox.Show("No puedes eliminar tu propio usuario.",
                                "Aviso",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult confirmacion = MessageBox.Show("¿Seguro que quieres eliminar este usuario?",
                                                            "Confirmar eliminación",
                                                            MessageBoxButton.YesNo,
                                                            MessageBoxImage.Warning);

            if (confirmacion == MessageBoxResult.Yes)
            {
                AdministradorRepository.EliminarUsuario(usuario.Id);
                usuarioEliminado = true;

                MessageBox.Show("Usuario eliminado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
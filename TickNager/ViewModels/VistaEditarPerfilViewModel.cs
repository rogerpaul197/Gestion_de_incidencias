using System.Windows;
using TickNager.Helper;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class VistaEditarPerfilViewModel
    {
        private DashboardViewModel _dashboardViewModel;

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Departamento { get; set; }

        public VistaEditarPerfilViewModel(DashboardViewModel dashboardViewModel)
        {
            _dashboardViewModel = dashboardViewModel;

            var usuario = SesionUsuarioHelper.UsuarioActual;

            Nombre = usuario.NombreUsuario;
            Apellido = usuario.ApellidoUsuario;
            Correo = usuario.CorreoUsuario;
            Departamento = usuario.Departamento;
        }

        public void Guardar()
        {
            Usuario usuario = SesionUsuarioHelper.UsuarioActual;

            usuario.NombreUsuario = Nombre;
            usuario.ApellidoUsuario = Apellido;
            usuario.CorreoUsuario = Correo;
            usuario.Departamento = Departamento;

            UsuarioRepository.ActualizarUsuario(usuario);

            MessageBox.Show("Perfil actualizado correctamente.");

            _dashboardViewModel.mostrarAjustes();
        }

        public void Cancelar()
        {
            _dashboardViewModel.mostrarAjustes();
        }
    }
}
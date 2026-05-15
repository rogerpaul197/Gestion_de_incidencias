using System.Collections.ObjectModel;
using System.Windows;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class FormularioCambiarRolUsuarioViewModel
    {
        private DashboardViewModel _dashboardViewModel;
        private Usuario _usuario;

        public ObservableCollection<string> Roles { get; set; }

        public string NombreCompleto
        {
            get { return _usuario.NombreCompleto; }
        }

        public string Correo
        {
            get { return _usuario.CorreoUsuario; }
        }

        public string RolSeleccionado { get; set; }

        public FormularioCambiarRolUsuarioViewModel(DashboardViewModel dashboardViewModel, Usuario usuario)
        {
            _dashboardViewModel = dashboardViewModel;
            _usuario = usuario;

            Roles = new ObservableCollection<string>();
            Roles.Add("Administrador");
            Roles.Add("Técnico");
            Roles.Add("Usuario");

            RolSeleccionado = usuario.RolUsuario;
        }

        public void GuardarRol()
        {
            if (string.IsNullOrWhiteSpace(RolSeleccionado))
            {
                MessageBox.Show("Selecciona un rol.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            UsuarioRepository.CambiarRolUsuario(_usuario.Id, RolSeleccionado);

            _usuario.RolUsuario = RolSeleccionado;

            MessageBox.Show("Rol actualizado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            _dashboardViewModel.mostrarVistaGestionUsuarios();
        }

        public void Cancelar()
        {
            _dashboardViewModel.mostrarVistaGestionUsuarios();
        }
    }
}
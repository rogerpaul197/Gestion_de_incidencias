using TickNager.Models;

namespace TickNager.ViewModels
{
    public class VistaPerfilUsuarioViewModel
    {
        private DashboardViewModel _dashboardViewModel;
        private Usuario _usuario;

        public string NombreCompleto
        {
            get { return _usuario.NombreCompleto; }
        }

        public string RolUsuario
        {
            get { return _usuario.RolUsuario; }
        }

        public string CorreoUsuario
        {
            get { return _usuario.CorreoUsuario; }
        }

        public string Departamento
        {
            get { return _usuario.Departamento; }
        }

        public string ImagenPerfil
        {
            get { return _usuario.ImagenPerfil; }
        }

        public VistaPerfilUsuarioViewModel(DashboardViewModel dashboardViewModel, Usuario usuario)
        {
            _dashboardViewModel = dashboardViewModel;
            _usuario = usuario;
        }

        public void Volver()
        {
            _dashboardViewModel.mostrarVistaGestionUsuarios();
        }
    }
}
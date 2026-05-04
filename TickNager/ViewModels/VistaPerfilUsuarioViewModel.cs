/// <summary>
/// Esta clase se encarga de mostrar la información del perfil de un usuario.
/// </summary>

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

        /// <summary>
        /// Constructor que recibe el ViewModel principal y el usuario seleccionado.
        /// </summary>
        /// <param name="dashboardViewModel">ViewModel principal del dashboard.</param>
        /// <param name="usuario">Usuario del que se mostrará el perfil.</param>
        public VistaPerfilUsuarioViewModel(DashboardViewModel dashboardViewModel, Usuario usuario)
        {
            _dashboardViewModel = dashboardViewModel;
            _usuario = usuario;
        }

        /// <summary>
        /// Esta función vuelve a la vista de gestión de usuarios.
        /// </summary>
        public void Volver()
        {
            _dashboardViewModel.mostrarVistaGestionUsuarios();
        }
    }
}
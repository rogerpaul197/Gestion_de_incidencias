using System.Windows.Controls;
using TickNager.UserControls;

namespace TickNager.ViewModels
{
    public class VistaIncidenciasViewModel
    {
        private DashboardViewModel _dashboardViewModel;

        private UserControl _mostrarUsuario;
        public UserControl MostrarUsuario
        {
            get { return _mostrarUsuario; }
            set
            {
                _mostrarUsuario = value;
            }
        }

        public VistaIncidenciasViewModel(DashboardViewModel dashboardViewModel)
        {
            _dashboardViewModel = dashboardViewModel;
        }

        public void mostrarUsuarioCreado()
        {
            MostrarUsuario = new UsuarioCreado();
        }
    }
}
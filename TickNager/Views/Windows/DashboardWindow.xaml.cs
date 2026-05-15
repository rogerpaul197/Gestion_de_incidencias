using System.Windows;
using TickNager.UserControls;
using TickNager.ViewModels;

namespace TickNager.Views.Windows
{
    public partial class DashboardWindow : Window
    {
        private DashboardViewModel _obj;

        public DashboardWindow()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel();
            _obj = DataContext as DashboardViewModel;
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarDashboard();
        }

        private void btnIncidencias_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarVistaIncidencias();
        }

        private void btnChatIncidencias_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarVistaChatIncidencias();
        }

        private void btnGestionUsuarios_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarVistaGestionUsuarios();
        }

        private void btnGruposTrabajo_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarVistaGrupoTrabajo();
        }

        private void btnCategorias_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarVistaCategorias();
        }

        private void btnAjustes_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarAjustes();
        }

        private void menuCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            _obj.CerrarSesion();
            this.Close();
        }

        private void btnMarcarNotificacionesLeidas_Click(object sender, RoutedEventArgs e)
        {
            _obj.MarcarNotificacionesComoLeidas();
        }
    }
}
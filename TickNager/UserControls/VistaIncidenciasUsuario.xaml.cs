using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    /// <summary>
    /// Lógica de interacción para VistaIncidenciasUsuario.xaml
    /// </summary>
    public partial class VistaIncidenciasUsuario : UserControl
    {
        private DashboardViewModel _dashboardViewModel;

        public VistaIncidenciasUsuario()
        {
            InitializeComponent();
        }

        public VistaIncidenciasUsuario(DashboardViewModel dashboardViewModel) : this()
        {
            _dashboardViewModel = dashboardViewModel;
            DataContext = new VistaIncidenciasViewModel(dashboardViewModel);
        }

        private void btnReportarIncidencia_Click(object sender, RoutedEventArgs e)
        {
            _dashboardViewModel.mostrarFormularioCrearIncidencia();
        }
    }
}

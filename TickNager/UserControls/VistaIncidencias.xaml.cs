using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class VistaIncidencias : UserControl
    {
        private DashboardViewModel _dashboardViewModel;
        private VistaIncidenciasViewModel _obj;

        public VistaIncidencias()
        {
            InitializeComponent();
        }

        public VistaIncidencias(DashboardViewModel dashboardViewModel) : this()
        {
            _dashboardViewModel = dashboardViewModel;
            DataContext = new VistaIncidenciasViewModel(dashboardViewModel);
            _obj = DataContext as VistaIncidenciasViewModel;
        }

        private void btnNuevaIncidencia_Click(object sender, RoutedEventArgs e)
        {
            _dashboardViewModel.mostrarFormularioCrearIncidencia();
        }

        private void btnLimpiarFiltros_Click(object sender, RoutedEventArgs e)
        {
            _obj.LimpiarFiltros();
        }
    }
}
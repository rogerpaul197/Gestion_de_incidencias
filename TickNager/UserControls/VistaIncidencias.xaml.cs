using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class VistaIncidencias : UserControl
    {
        private DashboardViewModel _dashboardViewModel;

        public VistaIncidencias()
        {
            InitializeComponent();
        }

        public VistaIncidencias(DashboardViewModel dashboardViewModel) : this()
        {
            _dashboardViewModel = dashboardViewModel;
        }

        private void btnNuevaIncidencia_Click(object sender, RoutedEventArgs e)
        {
            _dashboardViewModel.mostrarFormularioCrearIncidencia();
        }
    }
}
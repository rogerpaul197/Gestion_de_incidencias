using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class FormularioCrearIncidencia : UserControl
    {
        private DashboardViewModel _dashboardViewModel;

        public FormularioCrearIncidencia()
        {
            InitializeComponent();
        }

        public FormularioCrearIncidencia(DashboardViewModel dashboardViewModel) : this()
        {
            _dashboardViewModel = dashboardViewModel;
            DataContext = new FormularioCrearIncidenciaViewModel(dashboardViewModel);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is FormularioCrearIncidenciaViewModel obj)
            {
                obj.crearIncidencia();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is FormularioCrearIncidenciaViewModel obj)
            {
                obj.volverAVistaIncidencias();
            }
        }
    }
}
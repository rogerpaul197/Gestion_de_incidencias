using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class FormularioCrearIncidencia : UserControl
    {
        private DashboardViewModel _obj;
        private FormularioCrearIncidenciaViewModel _viewModel;

        public FormularioCrearIncidencia()
        {
            InitializeComponent();
        }

        public FormularioCrearIncidencia(DashboardViewModel dashboardViewModel) : this()
        {
            _obj = dashboardViewModel;
            DataContext = new FormularioCrearIncidenciaViewModel(dashboardViewModel);
            _viewModel = DataContext as FormularioCrearIncidenciaViewModel;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.crearIncidencia();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.volverAVistaIncidencias();
        }
    }
}
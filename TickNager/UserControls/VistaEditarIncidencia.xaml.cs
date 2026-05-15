using System.Windows;
using System.Windows.Controls;
using TickNager.Models;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class VistaEditarIncidencia : UserControl
    {
        private VistaEditarIncidenciaViewModel _obj;

        public VistaEditarIncidencia()
        {
            InitializeComponent();
        }

        public VistaEditarIncidencia(DashboardViewModel dashboardViewModel, Incidencia incidencia) : this()
        {
            DataContext = new VistaEditarIncidenciaViewModel(dashboardViewModel, incidencia);
            _obj = DataContext as VistaEditarIncidenciaViewModel;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            _obj.Guardar();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            _obj.Cancelar();
        }
    }
}
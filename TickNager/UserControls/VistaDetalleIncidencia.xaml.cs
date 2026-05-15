using System.Windows;
using System.Windows.Controls;
using TickNager.Models;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class VistaDetalleIncidencia : UserControl
    {
        private VistaDetalleIncidenciaViewModel _obj;

        public VistaDetalleIncidencia()
        {
            InitializeComponent();
        }

        public VistaDetalleIncidencia(DashboardViewModel dashboardViewModel, Incidencia incidencia) : this()
        {
            DataContext = new VistaDetalleIncidenciaViewModel(dashboardViewModel, incidencia);
            _obj = DataContext as VistaDetalleIncidenciaViewModel;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            _obj.Volver();
        }
    }
}
using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class FormularioCrearIncidencia : UserControl
    {
        private DashboardViewModel _obj;

        public FormularioCrearIncidencia()
        {
            InitializeComponent();
            DataContext = new FormularioCrearIncidenciaViewModel();
        }

        public FormularioCrearIncidencia(DashboardViewModel dashboardViewModel) : this()
        {
            
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            FormularioCrearIncidenciaViewModel obj = (FormularioCrearIncidenciaViewModel)DataContext;
            obj.crearIncidencia();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
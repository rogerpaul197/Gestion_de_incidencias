using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class VistaAjustes : UserControl
    {
        private VistaAjustesViewModel _obj;

        public VistaAjustes()
        {
            InitializeComponent();
        }

        public VistaAjustes(DashboardViewModel dashboardViewModel) : this()
        {
            DataContext = new VistaAjustesViewModel(dashboardViewModel);
            _obj = DataContext as VistaAjustesViewModel;
        }

        private void btnEditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            _obj.EditarPerfil();
        }

        private void btnGuardarContrasena_Click(object sender, RoutedEventArgs e)
        {
            _obj.CambiarContrasena();
        }
    }
}
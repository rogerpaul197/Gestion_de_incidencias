using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class VistaEditarPerfil : UserControl
    {
        private VistaEditarPerfilViewModel _obj;

        public VistaEditarPerfil()
        {
            InitializeComponent();
        }

        public VistaEditarPerfil(DashboardViewModel dashboardViewModel) : this()
        {
            DataContext = new VistaEditarPerfilViewModel(dashboardViewModel);
            _obj = DataContext as VistaEditarPerfilViewModel;
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
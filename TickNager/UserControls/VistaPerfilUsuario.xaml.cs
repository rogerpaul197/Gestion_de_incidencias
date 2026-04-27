using System.Windows;
using System.Windows.Controls;
using TickNager.Models;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class VistaPerfilUsuario : UserControl
    {
        private VistaPerfilUsuarioViewModel _obj;

        public VistaPerfilUsuario()
        {
            InitializeComponent();
        }

        public VistaPerfilUsuario(DashboardViewModel dashboardViewModel, Usuario usuario) : this()
        {
            DataContext = new VistaPerfilUsuarioViewModel(dashboardViewModel, usuario);
            _obj = DataContext as VistaPerfilUsuarioViewModel;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            _obj.Volver();
        }
    }
}
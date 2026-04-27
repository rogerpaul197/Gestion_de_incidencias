using System.Windows;
using System.Windows.Controls;
using TickNager.Models;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class FormularioCambiarRolUsuario : UserControl
    {
        private FormularioCambiarRolUsuarioViewModel _obj;

        public FormularioCambiarRolUsuario()
        {
            InitializeComponent();
        }

        public FormularioCambiarRolUsuario(DashboardViewModel dashboardViewModel, Usuario usuario) : this()
        {
            DataContext = new FormularioCambiarRolUsuarioViewModel(dashboardViewModel, usuario);
            _obj = DataContext as FormularioCambiarRolUsuarioViewModel;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            _obj.GuardarRol();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            _obj.Cancelar();
        }
    }
}
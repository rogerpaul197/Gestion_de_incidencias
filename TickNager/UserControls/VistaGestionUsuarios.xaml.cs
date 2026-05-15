using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    /// <summary>
    /// Lógica de interacción para VistaGestionUsuarios.xaml
    /// </summary>
    public partial class VistaGestionUsuarios : UserControl
    {
        private DashboardViewModel _obj;

        public VistaGestionUsuarios()
        {
            InitializeComponent();
        }

        public VistaGestionUsuarios(DashboardViewModel obj) : this()
        {
            _obj = obj;
            DataContext = new VistaGestionUsuariosViewModel();
        }

        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarFormularioCrearUsuario();
        }
    }
}
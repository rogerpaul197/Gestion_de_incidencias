using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    /// <summary>
    /// Lógica de interacción para FormularioCrearUsuario.xaml
    /// </summary>
    public partial class FormularioCrearUsuario : UserControl
    {
        private DashboardViewModel _dashboardObj;
        private FormularioCrearUsuarioViewModel _obj;

        public FormularioCrearUsuario()
        {
            InitializeComponent();
        }

        public FormularioCrearUsuario(DashboardViewModel obj) : this()
        {
            _dashboardObj = obj;
            DataContext = new FormularioCrearUsuarioViewModel(obj);
            _obj = DataContext as FormularioCrearUsuarioViewModel;
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            _obj.CrearUsuario();
        }
    }
}
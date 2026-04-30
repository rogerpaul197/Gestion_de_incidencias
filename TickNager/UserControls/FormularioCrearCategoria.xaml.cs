using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class FormularioCrearCategoria : UserControl
    {
        private DashboardViewModel _dashboardObj;
        private FormularioCrearCategoriaViewModel _obj;

        public FormularioCrearCategoria()
        {
            InitializeComponent();
        }

        public FormularioCrearCategoria(DashboardViewModel obj) : this()
        {
            _dashboardObj = obj;
            DataContext = new FormularioCrearCategoriaViewModel(obj);
            _obj = DataContext as FormularioCrearCategoriaViewModel;
        }

        private void btnSeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("La selección de imagen se pa después.");
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            _obj.CrearCategoria();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            _dashboardObj.mostrarVistaCategorias();
        }
    }
}
using System.Windows;
using System.Windows.Controls;
using TickNager.Helper;
using TickNager.ViewModels;

namespace TickNager.Views.Windows
{
    public partial class DashboardWindow : Window
    {
        private DashboardViewModel _obj;

        public DashboardWindow()
        {
            InitializeComponent();
            _obj = DataContext as DashboardViewModel;
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarDashboard();
        }

        private void btnIncidencias_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarVistaIncidencias();
        }

        private void btnGestionUsuarios_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarVistaGestionUsuarios();
        }

        private void btnEquipos_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarVistaEquipos();
        }

        private void btnCategorias_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarVistaCategorias();
        }

        private void btnAjustes_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarAjustes();
        }

        private void btnUsuario_Click(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;

            if (boton.ContextMenu != null)
            {
                boton.ContextMenu.PlacementTarget = boton;
                boton.ContextMenu.IsOpen = true;
            }
        }

        private void menuCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            SesionUsuario.CerrarSesion();

            LoginWindow login = new LoginWindow();
            login.Show();

            this.Close();
        }
    }
}
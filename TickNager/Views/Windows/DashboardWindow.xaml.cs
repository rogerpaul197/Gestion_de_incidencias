using System.Windows;
using TickNager.ViewModels;

namespace TickNager.Views.Windows
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
        }

        //Todos estas funciones son los botones del menú lateral
        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            DashboardViewModel ventanaDashboard = new DashboardViewModel();
            ventanaDashboard.mostrarDashboard();
        }

        private void btnIncidencias_Click(object sender, RoutedEventArgs e)
        {
            /*
            IncidenciasWindow ventanaIncidencias = new IncidenciasWindow();
            ventanaIncidencias.Show();*/
            this.Close();
        }

        private void btnGestionUsuarios_Click(object sender, RoutedEventArgs e)
        {
            /*
            GestionUsuariosWindow ventanaGestionUsuarios = new GestionUsuariosWindow();
            ventanaGestionUsuarios.Show();*/
            DashboardViewModel obj = new DashboardViewModel();
            obj.mostrarBotones();
            
        }

        private void btnEquipos_Click(object sender, RoutedEventArgs e)
        {
            /*
            EquiposWindow ventanaEquipos = new EquiposWindow();
            ventanaEquipos.Show();*/
            this.Close();
        }

        private void btnCategorias_Click(object sender, RoutedEventArgs e)
        {
            /*
            CategoriasWindow ventanaCategorias = new CategoriasWindow();
            ventanaCategorias.Show();*/
            this.Close();
        }

        private void btnAjustes_Click(object sender, RoutedEventArgs e)
        {
            /*
            AjustesWindow ventanaAjustes = new AjustesWindow();
            ventanaAjustes.Show();*/
            this.Close();
        }
    }
}

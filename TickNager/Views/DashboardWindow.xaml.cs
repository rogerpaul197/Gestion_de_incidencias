using System.Windows;

namespace TickNager.Views
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

        private void btnIncidencias_Click(object sender, RoutedEventArgs e)
        {
            IncidenciasWindow ventanaIncidencias = new IncidenciasWindow();
            ventanaIncidencias.Show();
            this.Close();
        }

        private void btnGestionUsuarios_Click(object sender, RoutedEventArgs e)
        {
            GestionUsuariosWindow ventanaGestionUsuarios = new GestionUsuariosWindow();
            ventanaGestionUsuarios.Show();
            this.Close();
        }

        private void btnEquipos_Click(object sender, RoutedEventArgs e)
        {
            EquiposWindow ventanaEquipos = new EquiposWindow();
            ventanaEquipos.Show();
            this.Close();
        }

        private void btnCategorias_Click(object sender, RoutedEventArgs e)
        {
            CategoriasWindow ventanaCategorias = new CategoriasWindow();
            ventanaCategorias.Show();
            this.Close();
        }

        private void btnAjustes_Click(object sender, RoutedEventArgs e)
        {
            AjustesWindow ventanaAjustes = new AjustesWindow();
            ventanaAjustes.Show();
            this.Close();
        }
    }
}

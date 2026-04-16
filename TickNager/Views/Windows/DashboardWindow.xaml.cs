using System.Windows;
using TickNager.UserControls;
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
            DashboardViewModel ventanaDashboard = this.DataContext as DashboardViewModel;
            if (ventanaDashboard != null)
                ventanaDashboard.mostrarDashboard();
        }

        private void btnIncidencias_Click(object sender, RoutedEventArgs e)
        {
            //método
            VistaIncidencias obj = new VistaIncidencias();
            FormularioCrearIncidencia obj2 = new FormularioCrearIncidencia();

            DashboardViewModel obj3 = this.DataContext as DashboardViewModel;

            obj3.mostrarVistaIncidencias(obj);
            
            obj3.mostrarFormulario(obj2);
        }

        private void btnGestionUsuarios_Click(object sender, RoutedEventArgs e)
        {
            //método
        }

        private void btnEquipos_Click(object sender, RoutedEventArgs e)
        {
            //método
        }

        private void btnCategorias_Click(object sender, RoutedEventArgs e)
        {
            //método
        }

        private void btnAjustes_Click(object sender, RoutedEventArgs e)
        {
            //método
        }
    }
}

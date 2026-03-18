using System.Windows;
using TickNager.Ventanas;

namespace TickNager
{
    /// <summary>
    /// Lógica de interacción para GestionUsuariosWindow.xaml
    /// </summary>
    public partial class GestionUsuariosWindow : Window
    {
        public GestionUsuariosWindow()
        {
            InitializeComponent();
        }

        private void btnAnadirUsuario_Click(object sender, RoutedEventArgs e)
        {
            CrearUsuarioWindow ventana = new CrearUsuarioWindow();
            ventana.Show();
        }
    }
}

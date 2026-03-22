using System.Windows;

namespace TickNager.Views
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
            CrearUsuarioWindow ventana = new CrearUsuarioWindow(this);
            ventana.Show();
        }

        public void AgregarUsuarioCreado(string nombreCompleto)
        {
            var usuario = new Views.ControladoresUsuario.UsuarioCreado(nombreCompleto);
            spUsuarios.Children.Add(usuario);
        }
    }
}

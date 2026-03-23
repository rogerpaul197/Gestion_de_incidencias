using System.Windows;

namespace TickNager.Views.Windows
{
    /// <summary>
    /// Lógica de interacción para CrearUsuarioWindow.xaml
    /// </summary>
    public partial class CrearUsuarioWindow : Window
    {
        private GestionUsuariosWindow ventanaPadre;
        string nombreUsuario;
        string apellidoUsuario;
        string departamentoUsuario;
        string numeroUsuario;
        string correoUsuario;
        string contrasenaUsuario;
        string contrasenaUsuarioConfirmacion;
        string nombreCompleto;

        public CrearUsuarioWindow(GestionUsuariosWindow ventana)
        {
            InitializeComponent();
            ventanaPadre = ventana;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            nombreUsuario = txtNombreUsuario.Text;
            apellidoUsuario = txtApellidoUsuario.Text;

            nombreCompleto = nombreUsuario + " " + apellidoUsuario;

            ventanaPadre.AgregarUsuarioCreado(nombreCompleto);

            this.Close();
        }
    }
}
using System.Windows;

namespace TickNager
{
    public partial class LoginWindow : Window
    {
        string nombre;
        string contrasena;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnSesion_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nombre = txtUsuario.Text;
            contrasena = txtContrasena.Password;

            ///Este es el usuario por defecto al iniciar el programa por primera vez
            ///que normalmente será el administrador.
            ///Después el propio administrador se encargará de crear las demás cuentas
            if (nombre == "admin" && contrasena == "1234")
            {
                MessageBox.Show("Se ha iniciado sesión correctamente");
                DashboardWindow ventanaDashboard = new DashboardWindow();
                ventanaDashboard.Show();
                this.Close();
            }
            else
            {
                txtError.Text = "El usuario o contraseña es incorrecto";
            }
        }
    }
}
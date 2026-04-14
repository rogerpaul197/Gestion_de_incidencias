using System.Windows;
using TickNager.ViewModels;

namespace TickNager.Views.Windows
{
    public partial class LoginWindow : Window
    {
        string nombre;
        string contrasena;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnIniciarSeision_Click(object sender, RoutedEventArgs e)
        {
            LoginWindowViewModel login = (LoginWindowViewModel)DataContext;
            DashboardWindow ventana = new DashboardWindow();
            login.iniciarSesion(ventana);
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            InformacionWindow ventanaInformacion = new InformacionWindow();
            ventanaInformacion.Show();
        }
    }
}
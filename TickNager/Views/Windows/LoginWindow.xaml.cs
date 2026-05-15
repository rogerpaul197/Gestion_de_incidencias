using System.Windows;
using TickNager.ViewModels;

namespace TickNager.Views.Windows
{
    public partial class LoginWindow : Window
    {
        private LoginWindowViewModel _obj;

        public LoginWindow()
        {
            InitializeComponent();
            _obj = new LoginWindowViewModel();
            DataContext = _obj;
        }

        private void btnIniciarSeision_Click(object sender, RoutedEventArgs e)
        {
            _obj.IniciarSesion();
            CerrarLoginSiInicioCorrecto();
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            _obj.MostrarAyuda();
        }

        private void txtContrasena_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _obj.Contrasena = txtContrasena.Password;
        }

        private void CerrarLoginSiInicioCorrecto()
        {
            if (_obj.InicioCorrecto)
            {
                this.Close();
            }
        }
    }
}
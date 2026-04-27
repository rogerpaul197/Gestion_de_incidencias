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
            _obj = DataContext as LoginWindowViewModel;
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

        private void CerrarLoginSiInicioCorrecto()
        {
            if (_obj.InicioCorrecto)
            {
                this.Close();
            }
        }
    }
}
using System.Windows;
using TickNager.ViewModels;

namespace TickNager.Views.Windows
{
    public partial class RegistroWindow : Window
    {
        public RegistroWindow()
        {
            InitializeComponent();
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            RegistroViewModel vm = (RegistroViewModel)DataContext;

            vm.Contrasena = txtContrasena.Password;
            vm.ConfirmacionContrasena = txtContrasenaConfirmacion.Password;
        }
    }
}
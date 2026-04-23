using System.Windows;
using TickNager.ViewModels;

namespace TickNager.Views.Windows
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnIniciarSeision_Click(object sender, RoutedEventArgs e)
        {
            LoginWindowViewModel login = (LoginWindowViewModel)DataContext;

            bool inicioCorrecto = login.iniciarSesion();

            if (inicioCorrecto)
            {
                DashboardWindow ventana = new DashboardWindow();
                ventana.Show();
                this.Close();
            }
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            InformacionWindow ventanaInformacion = new InformacionWindow();
            ventanaInformacion.Show();
        }
    }
}
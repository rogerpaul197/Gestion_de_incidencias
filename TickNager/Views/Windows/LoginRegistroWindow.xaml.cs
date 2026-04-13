using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TickNager.Views.Windows
{
    /// <summary>
    /// Lógica de interacción para LoginRegistroWindow.xaml
    /// </summary>
    public partial class LoginRegistroWindow : Window
    {
        public LoginRegistroWindow()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow ventana = new LoginWindow();
            ventana.Show();
            this.Close();
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            RegistroWindow ventana = new RegistroWindow();
            ventana.Show();
            this.Close();
        }
    }
}

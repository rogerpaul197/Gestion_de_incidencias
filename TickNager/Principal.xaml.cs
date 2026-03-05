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

namespace TickNager
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnIncidencias_Click(object sender, RoutedEventArgs e)
        {
            IncidenciasWindow ventanaIncidencia = new IncidenciasWindow();
            ventanaIncidencia.Show();
            this.Close();
        }
    }
}

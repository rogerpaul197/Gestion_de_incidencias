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

namespace TickNager.Ventanas
{
    /// <summary>
    /// Lógica de interacción para AvisoCampoVacioWindow.xaml
    /// </summary>
    public partial class AvisoCampoVacioWindow : Window
    {
        public AvisoCampoVacioWindow()
        {
            InitializeComponent();
        }

        private void btnAvisoCampoVacio_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

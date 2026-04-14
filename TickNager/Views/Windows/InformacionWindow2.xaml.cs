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
    /// Lógica de interacción para InformacionWindow2.xaml
    /// </summary>
    public partial class InformacionWindow2 : Window
    {
        public InformacionWindow2()
        {
            InitializeComponent();
        }

        private void btnEntendido_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

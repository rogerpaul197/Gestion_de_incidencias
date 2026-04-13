using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TickNager.ViewModels;

namespace TickNager.Views.Windows
{
    /// <summary>
    /// Lógica de interacción para InformacionWindow.xaml
    /// </summary>
    public partial class InformacionWindow : Window
    {
        public InformacionWindow()
        {
            InitializeComponent();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            InformacionWindow2 ventana2 = new InformacionWindow2();
            ventana2.Show();
            this.Close();
        }
    }
}

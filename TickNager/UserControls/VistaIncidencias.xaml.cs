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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    /// <summary>
    /// Lógica de interacción para VistaIncidencias.xaml
    /// </summary>
    public partial class VistaIncidencias : UserControl
    {
        public bool PresionoBoton;
        public VistaIncidencias()
        {
            InitializeComponent();
            PresionoBoton = false;
        }

        private void btnNuevaIncidencia_Click(object sender, RoutedEventArgs e)
        {
            PresionoBoton = true;
        }
    }
}

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
    /// Lógica de interacción para BotonesUsuario.xaml
    /// </summary>
    public partial class BotonesUsuario : UserControl
    {
        public BotonesUsuario()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Usa la función del ViewModel para mostrar el formulario de añadir usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnadirUsuario_Click(object sender, RoutedEventArgs e)
        {
            BotonesUsuarioViewModel b = new BotonesUsuarioViewModel();
            b.anadirUsuarioNuevo();
        }
    }
}

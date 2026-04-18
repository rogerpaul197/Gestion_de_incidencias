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
using TickNager.Models;
using TickNager.Repositories;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    /// <summary>
    /// Lógica de interacción para VistaGestionUsuarios.xaml
    /// </summary>
    public partial class VistaGestionUsuarios : UserControl
    {
        private DashboardViewModel _obj;

        public VistaGestionUsuarios()
        {
            InitializeComponent();
        }

        public VistaGestionUsuarios(DashboardViewModel obj) : this()
        {
            _obj = obj;
            DataContext = new VistaGestionUsuariosViewModel();
        }

        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            _obj.mostrarFormularioCrearUsuario();
        }
    }
}
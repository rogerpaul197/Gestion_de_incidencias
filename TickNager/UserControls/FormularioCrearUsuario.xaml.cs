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
using TickNager.Repositories;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    /// <summary>
    /// Lógica de interacción para FormularioCrearUsuario.xaml
    /// </summary>
    public partial class FormularioCrearUsuario : UserControl
    {
        private DashboardViewModel _obj;
        FormularioCrearUsuarioViewModel _obj2;

        public FormularioCrearUsuario()
        {
            InitializeComponent();
        }

        public FormularioCrearUsuario(DashboardViewModel obj) : this()
        {
            _obj = obj;
            DataContext = new FormularioCrearUsuarioViewModel(obj);
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            _obj2.CrearUsuario();
        }
    }
}
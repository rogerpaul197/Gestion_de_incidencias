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
    /// Lógica de interacción para VistaCategorias.xaml
    /// </summary>
    public partial class VistaCategorias : UserControl
    {
        private DashboardViewModel _dashboardObj;
        private VistaCategoriasViewModel _obj;

        public VistaCategorias()
        {
            InitializeComponent();
        }

        public VistaCategorias(DashboardViewModel obj) : this()
        {
            _dashboardObj = obj;
            DataContext = new VistaCategoriasViewModel(obj);
            _obj = DataContext as VistaCategoriasViewModel;
        }

        private void btnNuevaCategoria_Click(object sender, RoutedEventArgs e)
        {
            _dashboardObj.mostrarFormularioCrearCategoria();
        }
    }
}

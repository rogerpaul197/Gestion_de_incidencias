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
    /// Lógica de interacción para VistaIncidenciasUsuario.xaml
    /// </summary>
    public partial class VistaIncidenciasUsuario : UserControl
    {
        private DashboardViewModel _dashboardViewModel;

        public VistaIncidenciasUsuario()
        {
            InitializeComponent();
        }

        public VistaIncidenciasUsuario(DashboardViewModel dashboardViewModel) : this()
        {
            _dashboardViewModel = dashboardViewModel;
            DataContext = new VistaIncidenciasViewModel(dashboardViewModel);
        }

        private void btnReportarIncidencia_Click(object sender, RoutedEventArgs e)
        {
            _dashboardViewModel.mostrarFormularioCrearIncidencia();
        }
    }
}

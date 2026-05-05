using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class VistaGruposTrabajo : UserControl
    {
        private VistaGruposTrabajoViewModel _obj;

        public VistaGruposTrabajo(DashboardViewModel dashboardViewModel)
        {
            InitializeComponent();

            DataContext = new VistaGruposTrabajoViewModel(dashboardViewModel);
            _obj = DataContext as VistaGruposTrabajoViewModel;
        }

        private void btnCrearGrupo_Click(object sender, RoutedEventArgs e)
        {
            _obj.CrearGrupo();
        }

        private void btnRenombrarGrupo_Click(object sender, RoutedEventArgs e)
        {
            _obj.RenombrarGrupo(DataContext);
        }

        private void btnEliminarGrupo_Click(object sender, RoutedEventArgs e)
        {
            _obj.EliminarGrupo(DataContext);
        }

        private void btnNuevoGrupo_Click(object sender, RoutedEventArgs e)
        {
            _obj.MostrarFormularioCrearGrupo();
        }
    }
}
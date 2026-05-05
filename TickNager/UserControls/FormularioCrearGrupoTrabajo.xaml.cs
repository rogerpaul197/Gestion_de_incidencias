using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class FormularioCrearGrupoTrabajo : UserControl
    {
        private FormularioCrearGrupoTrabajoViewModel _obj;

        public FormularioCrearGrupoTrabajo(DashboardViewModel dashboardViewModel)
        {
            InitializeComponent();

            DataContext = new FormularioCrearGrupoTrabajoViewModel(dashboardViewModel);
            _obj = DataContext as FormularioCrearGrupoTrabajoViewModel;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            _obj.GuardarGrupo();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            _obj.Cancelar();
        }
    }
}
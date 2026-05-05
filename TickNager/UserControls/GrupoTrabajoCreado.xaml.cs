using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class GrupoTrabajoCreado : UserControl
    {
        private GrupoTrabajoCreadoViewModel _obj;

        public GrupoTrabajoCreado()
        {
            InitializeComponent();
            _obj = new GrupoTrabajoCreadoViewModel();
        }

        private void btnRenombrar_Click(object sender, RoutedEventArgs e)
        {
            _obj.RenombrarGrupo(DataContext);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            _obj.EliminarGrupo(DataContext);
        }
    }
}
using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class IncidenciaUsuarioCreada : UserControl
    {
        private IncidenciaUsuarioCreadaViewModel _obj;

        public IncidenciaUsuarioCreada()
        {
            InitializeComponent();
            _obj = new IncidenciaUsuarioCreadaViewModel();
        }

        private void menuVerDetalle_Click(object sender, RoutedEventArgs e)
        {
            _obj.VerDetalle(DataContext);
        }

        private void menuEditarIncidencia_Click(object sender, RoutedEventArgs e)
        {
            _obj.EditarIncidencia(DataContext);
        }
    }
}
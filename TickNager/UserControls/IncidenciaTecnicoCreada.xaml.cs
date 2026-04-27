using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class IncidenciaTecnicoCreada : UserControl
    {
        private IncidenciaTecnicoCreadaViewModel _obj;

        public IncidenciaTecnicoCreada()
        {
            InitializeComponent();
            _obj = new IncidenciaTecnicoCreadaViewModel();
        }

        private void menuVerDetalle_Click(object sender, RoutedEventArgs e)
        {
            _obj.VerDetalle(DataContext);
        }

        private void menuMarcarEnProceso_Click(object sender, RoutedEventArgs e)
        {
            _obj.MarcarEnProceso(DataContext);
        }

        private void menuMarcarResuelta_Click(object sender, RoutedEventArgs e)
        {
            _obj.MarcarResuelta(DataContext);
        }
    }
}
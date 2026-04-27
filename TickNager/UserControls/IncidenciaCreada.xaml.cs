using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class IncidenciaCreada : UserControl
    {
        private IncidenciaCreadaViewModel _obj;

        public IncidenciaCreada()
        {
            InitializeComponent();
            _obj = new IncidenciaCreadaViewModel();
        }

        private void menuVerDetalle_Click(object sender, RoutedEventArgs e)
        {
            _obj.VerDetalle(DataContext);
        }

        private void menuAsignarResponsable_Click(object sender, RoutedEventArgs e)
        {
            _obj.AsignarTecnico(DataContext);
        }
    }
}
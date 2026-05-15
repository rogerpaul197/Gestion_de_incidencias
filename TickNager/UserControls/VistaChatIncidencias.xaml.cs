using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class VistaChatIncidencias : UserControl
    {
        private VistaChatIncidenciasViewModel _obj;

        public VistaChatIncidencias()
        {
            InitializeComponent();
        }

        public VistaChatIncidencias(DashboardViewModel dashboardViewModel) : this()
        {
            DataContext = new VistaChatIncidenciasViewModel();
            _obj = DataContext as VistaChatIncidenciasViewModel;
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            _obj.CrearComentario();
        }
    }
}
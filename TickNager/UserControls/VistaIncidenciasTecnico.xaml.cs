using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    /// <summary>
    /// Lógica de interacción para VistaIncidenciasTecnico.xaml
    /// </summary>
    public partial class VistaIncidenciasTecnico : UserControl
    {
        public VistaIncidenciasTecnico()
        {
            InitializeComponent();
            DataContext = new VistaIncidenciasViewModel();
        }
    }
}

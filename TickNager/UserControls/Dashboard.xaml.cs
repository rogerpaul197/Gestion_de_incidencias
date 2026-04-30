using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            DataContext = new DashboardDatosViewModel();
        }
    }
}

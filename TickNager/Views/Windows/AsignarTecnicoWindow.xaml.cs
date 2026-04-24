using System.Windows;
using TickNager.ViewModels;

namespace TickNager.Views.Windows
{
    public partial class AsignarTecnicoWindow : Window
    {
        private AsignarTecnicoWindowViewModel _obj;

        public AsignarTecnicoWindow(int idIncidencia)
        {
            InitializeComponent();

            DataContext = new AsignarTecnicoWindowViewModel(idIncidencia);
            _obj = DataContext as AsignarTecnicoWindowViewModel;
        }

        private void RadioTecnico_Checked(object sender, RoutedEventArgs e)
        {
            _obj.SeleccionarTecnico(sender);
        }

        private void btnAsignar_Click(object sender, RoutedEventArgs e)
        {
            if (_obj.AsignarTecnico())
            {
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
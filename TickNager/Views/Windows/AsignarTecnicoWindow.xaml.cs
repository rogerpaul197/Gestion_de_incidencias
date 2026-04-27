using System.Windows;
using TickNager.ViewModels;

namespace TickNager.Views.Windows
{
    public partial class AsignarTecnicoWindow : Window
    {
        private AsignarTecnicoWindowViewModel _obj;
        public bool AsignacionRealizada { get; set; }

        public AsignarTecnicoWindow(int idIncidencia)
        {
            InitializeComponent();

            DataContext = new AsignarTecnicoWindowViewModel(idIncidencia);
            _obj = DataContext as AsignarTecnicoWindowViewModel;
        }

        private void btnAsignar_Click(object sender, RoutedEventArgs e)
        {
            if (_obj.AsignarTecnico())
            {
                AsignacionRealizada = true;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
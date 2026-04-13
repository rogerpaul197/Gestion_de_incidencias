using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using TickNager.Commands;
using TickNager.UserControls;

namespace TickNager.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private UserControl _vistaActual;

        public UserControl VistaActual
        {
            get { return _vistaActual; }
            set
            {
                _vistaActual = value;
                OnPropertyChanged();
            }
        }

        public ICommand MostrarDashboard { get; set; }
        public ICommand MostrarBotones { get; set; }

        public DashboardViewModel()
        {
            MostrarDashboard = new RelayCommand(mostrarDashboard);
            // Para que al abrir la ventana ya se vea el Dashboard por defecto.
            VistaActual = new Dashboard();

            MostrarBotones = new RelayCommand(mostrarBotones);
        }

        public void mostrarDashboard(object obj)
        {
            VistaActual = new Dashboard();
        }

        /// <summary>
        /// Muestra los botones para le gestión de los usuarios.
        /// </summary>
        public void mostrarBotones(object obj)
        {
            VistaActual = new BotonesUsuario();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
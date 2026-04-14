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
        //Aquí se van a guardar las los UserControls que serán las vistas en la parte derecha (dependiendo de la función, cada función muestra una vista diferente).
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

        public DashboardViewModel()
        {
            // Para que al abrir la ventana ya se vea el Dashboard por defecto.
            VistaActual = new Dashboard();
        }

        public void mostrarDashboard()
        {
            VistaActual = new Dashboard();
        }

        /// <summary>
        /// Muestra los botones para le gestión de los usuarios.
        /// </summary>
        public void mostrarBotones()
        {
            VistaActual = new BotonesUsuario(this);
        }

        /// <summary>
        /// Muestra el formulario para crear un nuevo usuario.
        /// </summary>
        public void mostrarFormularioCrearUsuario()
        {
            VistaActual = new FormularioCrearUsuario();
        }

        /// <summary>
        /// Muestra el usuario creado.
        /// </summary>
        public void mostrarUsuarioCreado()
        {
            VistaActual = new UsuarioCreado();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
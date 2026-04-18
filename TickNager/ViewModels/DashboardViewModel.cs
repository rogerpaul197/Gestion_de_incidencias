using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using TickNager.Commands;
using TickNager.UserControls;
using TickNager.Models;

namespace TickNager.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        //Aquí se van a guardar las los UserControls que serán las vistas en la parte derecha (dependiendo de la función, cada función muestra una vista diferente).
        private UserControl _contenido;

        public UserControl Contenido
        {
            get { return _contenido; }
            set
            {
                _contenido = value;
                OnPropertyChanged();
            }
        }

        public DashboardViewModel()
        {
            Contenido = new Dashboard();
        }

        public void mostrarDashboard()
        {
            Contenido = new Dashboard();
        }

        //Gestión de incidencias
        public void mostrarVistaIncidencias()
        {
            Contenido = new VistaIncidencias(this);
        }

        public void mostrarFormularioCrearIncidencia()
        {
            Contenido = new FormularioCrearIncidencia(this);
        }

        //Gestión de usuarios
        public void mostrarVistaGestionUsuarios()
        {
            Contenido = new VistaGestionUsuarios(this);
        }

        public void mostrarFormularioCrearUsuario()
        {
            Contenido = new FormularioCrearUsuario(this);
        }

        //
        public void mostrarVistaEquipos()
        {
            Contenido = new EquiposView();
        }

        public void mostrarVistaCategorias()
        {
            Contenido = new CategoriasView();
        }

        public void mostrarAjustes()
        {
            Contenido = new AjustesView();
        }

        /*
        /// <summary>
        /// Muestra los botones para le gestión de los usuarios.
        /// </summary>
        public void mostrarBotones()
        {
            Contenido = new BotonesUsuario(this);
        }

        /// <summary>
        /// Muestra la vista de incidencias.
        /// </summary>
        public void mostrarVistaIncidencias(UserControl vista)
        {
            Contenido = vista;
        }

        public void mostrarFormulario(UserControl vista)
        {
            Contenido = vista;
        }

        /// <summary>
        /// Muestra el usuario creado.
        /// </summary>
        public void mostrarUsuarioCreado()
        {
            Contenido = new UsuarioCreado();
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
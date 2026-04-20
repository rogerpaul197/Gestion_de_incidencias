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

        //Equipos
        public void mostrarVistaEquipos()
        {
            //Contenido = new EquiposView();
        }

        //Categorías
        public void mostrarVistaCategorias()
        {
            Contenido = new VistaCategorias(this);
        }

        public void mostrarFormularioCrearCategoria()
        {
            Contenido = new FormularioCrearCategoria(this);
        }

        //Ajustes
        public void mostrarAjustes()
        {
            //Contenido = new AjustesView();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
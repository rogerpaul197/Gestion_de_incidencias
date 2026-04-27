///<summary>
/// Aquí se va a manejar todo sobre las vistas
/// </summary>
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using TickNager.Commands;
using TickNager.UserControls;
using TickNager.Models;
using TickNager.Helper;
using TickNager.Views.Windows;

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

        public string NombreUsuarioActual
        {
            get
            {
                if (SesionUsuario.UsuarioActual != null)
                {
                    return SesionUsuario.UsuarioActual.NombreUsuario;
                }

                return "";
            }
        }

        public string ImagenUsuarioActual
        {
            get
            {
                if (SesionUsuario.UsuarioActual != null)
                {
                    return SesionUsuario.UsuarioActual.ImagenPerfil;
                }

                return "/Imagenes/Iconos/interrogacion_por_defecto.png";
            }
        }

        public DashboardViewModel()
        {
            Contenido = new Dashboard();
        }

        public void CerrarSesion()
        {
            SesionUsuario.CerrarSesion();

            LoginWindow login = new LoginWindow();
            login.Show();
        }

        public void mostrarDashboard()
        {
            Contenido = new Dashboard();
        }

        //Gestión de incidencias
        public void mostrarVistaIncidencias()
        {
            string rolUsuario = SesionUsuario.UsuarioActual?.RolUsuario;

            if (rolUsuario == "Administrador")
            {
                Contenido = new VistaIncidencias(this);
            }
            else if (rolUsuario == "Técnico")
            {
                Contenido = new VistaIncidenciasTecnico();
            }
            else if (rolUsuario == "Usuario")
            {
                Contenido = new VistaIncidenciasUsuario(this);
            }
            else
            {
                Contenido = new VistaIncidencias(this);
            }
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
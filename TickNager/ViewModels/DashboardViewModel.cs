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
        public static DashboardViewModel obj { get; set; }

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

        public bool EsAdmin
        {
            get
            {
                return SesionUsuario.UsuarioActual != null &&
                       SesionUsuario.UsuarioActual.RolUsuario == "Administrador";
            }
        }

        public bool EsTecnico
        {
            get
            {
                return SesionUsuario.UsuarioActual != null &&
                       SesionUsuario.UsuarioActual.RolUsuario == "Técnico";
            }
        }

        public bool EsUsuario
        {
            get
            {
                return SesionUsuario.UsuarioActual != null &&
                       SesionUsuario.UsuarioActual.RolUsuario == "Usuario";
            }
        }

        public bool VerDashboard
        {
            get
            {
                return EsAdmin || EsTecnico;
            }
        }

        public DashboardViewModel()
        {
            obj = this;
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
            if (!EsAdmin)
                return;

            Contenido = new VistaGestionUsuarios(this);
        }

        public void mostrarFormularioCrearUsuario()
        {
            if (!EsAdmin)
                return;

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
            Contenido = new VistaAjustes();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }

        public void mostrarFormularioCambiarRolUsuario(Usuario usuario)
        {
            Contenido = new FormularioCambiarRolUsuario(this, usuario);
        }

        public void mostrarVistaPerfilUsuario(Usuario usuario)
        {
            Contenido = new VistaPerfilUsuario(this, usuario);
        }
    }
}
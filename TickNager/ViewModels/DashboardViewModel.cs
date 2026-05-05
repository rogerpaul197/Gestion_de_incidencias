///<summary>
/// Aquí se va a manejar todo sobre las vistas
/// </summary>
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using TickNager.Commands;
using TickNager.Helper;
using TickNager.Models;
using TickNager.Repositories;
using TickNager.UserControls;
using TickNager.Views.Windows;
using System.Collections.ObjectModel;


namespace TickNager.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public static DashboardViewModel obj { get; set; }

        private ObservableCollection<Notificacion> _notificaciones;

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
                if (SesionUsuarioHelper.UsuarioActual != null)
                {
                    return SesionUsuarioHelper.UsuarioActual.NombreUsuario;
                }

                return "";
            }
        }

        public string ImagenUsuarioActual
        {
            get
            {
                if (SesionUsuarioHelper.UsuarioActual != null)
                {
                    return SesionUsuarioHelper.UsuarioActual.ImagenPerfil;
                }

                return "/Imagenes/Iconos/interrogacion_por_defecto.png";
            }
        }

        public bool EsAdmin
        {
            get
            {
                return SesionUsuarioHelper.UsuarioActual != null && SesionUsuarioHelper.UsuarioActual.RolUsuario == "Administrador";
            }
        }

        public bool EsTecnico
        {
            get
            {
                return SesionUsuarioHelper.UsuarioActual != null && SesionUsuarioHelper.UsuarioActual.RolUsuario == "Técnico";
            }
        }

        public bool EsUsuario
        {
            get
            {
                return SesionUsuarioHelper.UsuarioActual != null && SesionUsuarioHelper.UsuarioActual.RolUsuario == "Usuario";
            }
        }

        public bool VerDashboard
        {
            get
            {
                return true;
            }
        }

        public ObservableCollection<Notificacion> Notificaciones
        {
            get { return _notificaciones; }
            set
            {
                _notificaciones = value;
                OnPropertyChanged();
            }
        }

        public bool HayNotificaciones
        {
            get
            {
                int idUsuario = SesionUsuarioHelper.UsuarioActual.Id;
                return NotificacionRepository.ContarNoLeidas(idUsuario) > 0;
            }
        }

        public string NotificacionPendientes
        {
            get
            {
                int pendientes = IncidenciaRepository.ObtenerIncidenciasPendientes();
                return "Pendientes: " + pendientes;
            }
        }

        public string NotificacionAsignadas
        {
            get
            {
                int asignadas = IncidenciaRepository.ObtenerIncidenciasAsignadas();
                return "Asignadas: " + asignadas;
            }
        }

        public DashboardViewModel()
        {
            obj = this;

            Contenido = new Dashboard();

            CargarNotificaciones();
        }

        public void CerrarSesion()
        {
            SesionUsuarioHelper.CerrarSesion();

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
            string rolUsuario = SesionUsuarioHelper.UsuarioActual?.RolUsuario;

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


        //Grupos de trabajo
        public void mostrarVistaGrupoTrabajo()
        {
            Contenido = new VistaGruposTrabajo(this);
        }

        public void mostrarFormularioCrearGrupoTrabajo()
        {
            Contenido = new FormularioCrearGrupoTrabajo(this);
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
            Contenido = new VistaAjustes(this);
        }

        public void mostrarVistaEditarPerfil()
        {
            Contenido = new VistaEditarPerfil(this);
        }

        public void mostrarFormularioCambiarRolUsuario(Usuario usuario)
        {
            Contenido = new FormularioCambiarRolUsuario(this, usuario);
        }

        public void mostrarVistaPerfilUsuario(Usuario usuario)
        {
            Contenido = new VistaPerfilUsuario(this, usuario);
        }

        public void CargarNotificaciones()
        {
            int idUsuario = SesionUsuarioHelper.UsuarioActual.Id;

            var lista = NotificacionRepository.ObtenerNotificacionesUsuario(idUsuario);

            Notificaciones = new ObservableCollection<Notificacion>(lista);

            OnPropertyChanged(nameof(HayNotificaciones));
        }

        public void MarcarNotificacionesComoLeidas()
        {
            int idUsuario = SesionUsuarioHelper.UsuarioActual.Id;

            NotificacionRepository.MarcarTodasComoLeidas(idUsuario);

            OnPropertyChanged(nameof(HayNotificaciones));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
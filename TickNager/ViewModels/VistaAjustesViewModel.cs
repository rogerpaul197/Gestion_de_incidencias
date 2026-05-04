/// <summary>
/// Esta clase se encarga de la lógica de la vista de ajustes.
/// </summary>

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TickNager.Helper;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class VistaAjustesViewModel : INotifyPropertyChanged
    {
        private DashboardViewModel _obj;
        private string _nuevaContrasena;
        private string _confirmarContrasena;

        public string NuevaContrasena
        {
            get { return _nuevaContrasena; }
            set
            {
                _nuevaContrasena = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmarContrasena
        {
            get { return _confirmarContrasena; }
            set
            {
                _confirmarContrasena = value;
                OnPropertyChanged();
            }
        }

        public string NombreCompleto
        {
            get { return SesionUsuarioHelper.UsuarioActual.NombreCompleto; }
        }

        public string Correo
        {
            get { return SesionUsuarioHelper.UsuarioActual.CorreoUsuario; }
        }

        public string Rol
        {
            get { return SesionUsuarioHelper.UsuarioActual.RolUsuario; }
        }

        public string Departamento
        {
            get { return SesionUsuarioHelper.UsuarioActual.Departamento; }
        }

        /// <summary>
        /// Constructor que recibe el ViewModel principal.
        /// </summary>
        /// <param name="dashboardViewModel">ViewModel principal del dashboard.</param>
        public VistaAjustesViewModel(DashboardViewModel dashboardViewModel)
        {
            _obj = dashboardViewModel;
        }

        /// <summary>
        /// Esta función muestra la vista para editar el perfil.
        /// </summary>
        public void EditarPerfil()
        {
            _obj.mostrarVistaEditarPerfil();
        }

        /// <summary>
        /// Esta función cambia la contraseña del usuario actual.
        /// </summary>
        public void CambiarContrasena()
        {
            if (NuevaContrasena == null || NuevaContrasena == "" || ConfirmarContrasena == null || ConfirmarContrasena == "")
            {
                MessageBox.Show("Completa los campos de contraseña.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (NuevaContrasena != ConfirmarContrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string contrasenaHash = HashPasswordHelper.HashPassword(NuevaContrasena);

            UsuarioRepository.CambiarContrasena(SesionUsuarioHelper.UsuarioActual.Id, contrasenaHash);

            MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            NuevaContrasena = "";
            ConfirmarContrasena = "";
        }

        /// <summary>
        /// Evento que avisa a la vista cuando cambia una propiedad.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Esta función notifica a la vista que una propiedad cambió.
        /// </summary>
        /// <param name="nombrePropiedad">Nombre de la propiedad que cambió.</param>
        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
using System.Windows;
using TickNager.Helper;
using TickNager.Repositories;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        public VistaAjustesViewModel(DashboardViewModel dashboardViewModel)
        {
            _obj = dashboardViewModel;
        }

        public void EditarPerfil()
        {
            _obj.mostrarVistaEditarPerfil();
        }

        public void CambiarContrasena()
        {
            if (string.IsNullOrWhiteSpace(NuevaContrasena) || string.IsNullOrWhiteSpace(ConfirmarContrasena))
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
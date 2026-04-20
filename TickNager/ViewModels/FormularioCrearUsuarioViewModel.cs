using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TickNager.Helper;
using TickNager.Models;
using TickNager.Repositories;
using TickNager.UserControls;
using TickNager.ViewModels;

namespace TickNager.ViewModels
{
    public class FormularioCrearUsuarioViewModel : INotifyPropertyChanged
    {
        private string _nombre;
        private string _apellido;
        private string _rol;
        private string _genero;
        private string _departamento;
        private string _numero;
        private string _correo;
        private string _contrasena;
        private string _confirmarContrasena;
        private string _imagenPerfil = "/Imagenes/Iconos/perfil_usuario.png";
        private DashboardViewModel _obj;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                _apellido = value;
                OnPropertyChanged();
            }
        }

        public string Rol
        {
            get { return _rol; }
            set
            {
                _rol = value;
                OnPropertyChanged();
                ActualizarImagen();
            }
        }

        public string Genero
        {
            get { return _genero; }
            set
            {
                _genero = value;
                OnPropertyChanged();
                ActualizarImagen();
            }
        }

        public string Departamento
        {
            get { return _departamento; }
            set
            {
                _departamento = value;
                OnPropertyChanged();
            }
        }

        public string Numero
        {
            get { return _numero; }
            set
            {
                _numero = value;
                OnPropertyChanged();
            }
        }

        public string Correo
        {
            get { return _correo; }
            set
            {
                _correo = value;
                OnPropertyChanged();
            }
        }

        public string Contrasena
        {
            get { return _contrasena; }
            set
            {
                _contrasena = value;
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

        public string ImagenPerfil
        {
            get { return _imagenPerfil; }
            set
            {
                _imagenPerfil = value;
                OnPropertyChanged();
            }
        }

        public FormularioCrearUsuarioViewModel()
        {

        }

        public FormularioCrearUsuarioViewModel(DashboardViewModel obj)
        {
            _obj = obj;
        }

        public void CrearUsuario()
        {
            if (ConfirmarContrasena != Contrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Usuario usuarioNuevo = new Usuario(Nombre, Apellido, Rol, Genero, Departamento, Numero, Correo, Contrasena);
                UsuarioRepository.RegistrarUsuario(usuarioNuevo);
                MessageBox.Show("Usuario creado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                _obj.mostrarVistaGestionUsuarios();
            }
        }

        private void ActualizarImagen()
        {
            ImagenPerfil = FuncionesHelper.ObtenerImagenPerfil(Rol, Genero);
        }

        
    }
}
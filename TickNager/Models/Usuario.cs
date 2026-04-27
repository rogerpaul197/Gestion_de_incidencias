using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TickNager.Models
{
    public class Usuario : INotifyPropertyChanged
    {
        private int _id;
        private string _nombreUsuario;
        private string _apellidoUsuario;
        private string _rolUsuario;

        ///Se utilizan para poder asignar una imagen masculino o femenino
        ///No hace falta guardar estas variables aquí, porque la imagen se 
        ///controla desde la ventana de registro según el rol y el género elegidos.
        private string _generoUsuario;

        private string _departamento;
        private string? _numeroUsuario;
        private string _correoUsuario;
        private string _contrasenaUsuario;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set
            {
                _nombreUsuario = value;
            }
        }

        public string ApellidoUsuario
        {
            get { return _apellidoUsuario; }
            set
            {
                _apellidoUsuario = value;
            }
        }

        public string NombreCompleto
        {
            get
            {
                return NombreUsuario + " " + ApellidoUsuario;
            }
        }

        public string RolUsuario
        {
            get { return _rolUsuario; }
            set
            {
                _rolUsuario = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ImagenPerfil));
            }
        }

        public string GeneroUsuario
        {
            get { return _generoUsuario; }
            set
            {
                _generoUsuario = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ImagenPerfil));
            }
        }

        public string Departamento
        {
            get { return _departamento; }
            set
            {
                _departamento = value;
            }
        }

        public string? NumeroUsuario
        {
            get { return _numeroUsuario; }
            set
            {
                _numeroUsuario = value;
            }
        }

        public string CorreoUsuario
        {
            get { return _correoUsuario; }
            set
            {
                _correoUsuario = value;
            }
        }

        public string ContrasenaUsuario
        {
            get { return _contrasenaUsuario; }
            set
            {
                _contrasenaUsuario = value;
            }
        }

        public string ImagenPerfil
        {
            get
            {
                return Helper.FuncionesHelper.ObtenerImagenPerfil(RolUsuario, GeneroUsuario);
            }
        }

        public Usuario()
        {

        }

        //Se va usar a la hora de iniciar sesión.
        public Usuario(string correoUsuario, string contrasenaUsuario)
        {
            _correoUsuario = correoUsuario;
            _contrasenaUsuario = contrasenaUsuario;
        }

        public Usuario(string nombreUsuario, string apellidoUsuario, string? numeroUsuario, string generoUsuario, string correoUsuario, string contrasenaUsuario)
        {
            _nombreUsuario = nombreUsuario;
            _apellidoUsuario = apellidoUsuario;
            _numeroUsuario = numeroUsuario;
            _generoUsuario = generoUsuario;
            _correoUsuario = correoUsuario;
            _contrasenaUsuario = contrasenaUsuario;
        }

        public Usuario(string nombreUsuario, string apellidoUsuario, string rolUsuario, string generoUsuario, string departamento, string? numeroUsuario, string correoUsuario, string contrasenaUsuario)
        {
            _nombreUsuario = nombreUsuario;
            _apellidoUsuario = apellidoUsuario;
            _rolUsuario = rolUsuario;
            _generoUsuario = generoUsuario;
            _departamento = departamento;
            _numeroUsuario = numeroUsuario;
            _correoUsuario = correoUsuario;
            _contrasenaUsuario = contrasenaUsuario;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
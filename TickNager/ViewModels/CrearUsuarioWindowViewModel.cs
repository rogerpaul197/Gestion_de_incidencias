using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TickNager.Commands;
using TickNager.Helper;
using TickNager.Models;

namespace TickNager.ViewModels
{
    public class CrearUsuarioWindowViewModel : INotifyPropertyChanged
    {
        private string _nombre;
        private string _apellido;
        private string _rol;
        private string _genero;
        private string _departamento;
        private string _numero;
        private string _correo;

        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }

        public string Apellido
        {
            get => _apellido;
            set
            {
                _apellido = value;
                OnPropertyChanged();
            }
        }

        public string Rol
        {
            get => _rol;
            set
            {
                _rol = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ImagenPerfil));
            }
        }

        public string Genero
        {
            get => _genero;
            set
            {
                _genero = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ImagenPerfil));
            }
        }

        public string Departamento
        {
            get => _departamento;
            set
            {
                _departamento = value;
                OnPropertyChanged();
            }
        }

        public string Numero
        {
            get => _numero;
            set
            {
                _numero = value;
                OnPropertyChanged();
            }
        }

        public string Correo
        {
            get => _correo;
            set
            {
                _correo = value;
                OnPropertyChanged();
            }
        }

        public string ImagenPerfil
        {
            get
            {
                if (Rol == "Administrador" && Genero == "Mujer")
                    return "/Imagenes/Iconos/perfil_administradora.png";

                if (Rol == "Administrador" && Genero == "Hombre")
                    return "/Imagenes/Iconos/perfil_administrador.png";

                if (Rol == "Técnico" && Genero == "Mujer")
                    return "/Imagenes/Iconos/perfil_tecnica.png";

                if (Rol == "Técnico" && Genero == "Hombre")
                    return "/Imagenes/Iconos/perfil_tecnico.png";

                if (Rol == "Usuario" && Genero == "Mujer")
                    return "/Imagenes/Iconos/perfil_usuaria.png";

                if (Rol == "Usuario" && Genero == "Hombre")
                    return "/Imagenes/Iconos/perfil_usuario.png";

                return "/Imagenes/Iconos/perfil_usuario.png";
            }
        }

        public ICommand CrearUsuario { get; set; }

        public CrearUsuarioWindowViewModel()
        {
            CrearUsuario = new RelayCommand(crearUsuario);
        }

        public void crearUsuario(object obj)
        {
            Usuario usuarioNuevo = new Usuario(Nombre, Apellido, Rol, Departamento, Numero, Correo);

            DatabaseHelper.iniciarConexion();
            FuncionesHelper.RegistarUsuario(usuarioNuevo);

            MessageBox.Show("Se creó el usuario correctamente.");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
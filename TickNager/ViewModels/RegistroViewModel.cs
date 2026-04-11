using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TickNager.Commands;
using TickNager.Helper;
using TickNager.Models;
using TickNager.Repositories;
using TickNager.Views.Windows;

namespace TickNager.ViewModels
{
    public class RegistroViewModel : INotifyPropertyChanged
    {
        private string _nombre;
        private string _apellido;
        private string _rol;
        private string _numero;
        private string _genero;
        private string _correo;
        private string _contrasena;
        private string _confirmacionContrasena;
        private string _textoRol = "Selecciona un rol";
        private string _imagenPerfil = "/Imagenes/Iconos/perfil_usuario.png";

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
                ActualizarTextoRolEImagen();
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

        public string Genero
        {
            get => _genero;
            set
            {
                _genero = value;
                OnPropertyChanged();
                ActualizarTextoRolEImagen();
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

        public string Contrasena
        {
            get => _contrasena;
            set
            {
                _contrasena = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmacionContrasena
        {
            get => _confirmacionContrasena;
            set
            {
                _confirmacionContrasena = value;
                OnPropertyChanged();
            }
        }

        public string TextoRol
        {
            get => _textoRol;
            set
            {
                _textoRol = value;
                OnPropertyChanged();
            }
        }

        public string ImagenPerfil
        {
            get => _imagenPerfil;
            set
            {
                _imagenPerfil = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegistroUsuario { get; }

        public RegistroViewModel()
        {
            RegistroUsuario = new RelayCommand(registroUsuario, puedeRegistrarUsuario);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }

        /// <summary>
        /// Esta función actualiza el texto del rol y la imagen de perfil dependiendo del rol y del género seleccionados por el usuario.
        /// </summary>
        private void ActualizarTextoRolEImagen()
        {
            if (string.IsNullOrWhiteSpace(Rol) || string.IsNullOrWhiteSpace(Genero))
            {
                if (Rol == "Administrador")
                {
                    TextoRol = "Administrador";
                    ImagenPerfil = "/Imagenes/Iconos/perfil_administrador.png";
                }
                else if (Rol == "Técnico")
                {
                    TextoRol = "Técnico";
                    ImagenPerfil = "/Imagenes/Iconos/perfil_tecnico.png";
                }
                else if (Rol == "Usuario")
                {
                    TextoRol = "Usuario";
                    ImagenPerfil = "/Imagenes/Iconos/perfil_usuario.png";
                }
                else
                {
                    TextoRol = "Selecciona un rol";
                    ImagenPerfil = "/Imagenes/Iconos/perfil_usuario.png";
                }

                return;
            }

            if (Rol == "Administrador")
            {
                if (Genero == "Mujer")
                {
                    TextoRol = "Administradora";
                    ImagenPerfil = "/Imagenes/Iconos/perfil_administradora.png";
                }
                else
                {
                    TextoRol = "Administrador";
                    ImagenPerfil = "/Imagenes/Iconos/perfil_administrador.png";
                }
            }
            else if (Rol == "Técnico")
            {
                if (Genero == "Mujer")
                {
                    TextoRol = "Técnica";
                    ImagenPerfil = "/Imagenes/Iconos/perfil_tecnica.png";
                }
                else
                {
                    TextoRol = "Técnico";
                    ImagenPerfil = "/Imagenes/Iconos/perfil_tecnico.png";
                }
            }
            else if (Rol == "Usuario")
            {
                if (Genero == "Mujer")
                {
                    TextoRol = "Usuaria";
                    ImagenPerfil = "/Imagenes/Iconos/perfil_usuaria.png";
                }
                else
                {
                    TextoRol = "Usuario";
                    ImagenPerfil = "/Imagenes/Iconos/perfil_usuario.png";
                }
            }
            else
            {
                TextoRol = "Selecciona un rol";
                ImagenPerfil = "/Imagenes/Iconos/perfil_usuario.png";
            }
        }

        /// <summary>
        /// Esta función se encarga de validar que los campos no estén vacíos y luego crea un nuevo usuario con los datos ingresados. Si algún campo está vacío, se muestra una ventana de aviso.
        /// </summary>
        /// <returns>
        /// Deveulve un objeto de tipo Usuario con los datos ingresados por el usuario. Si algún campo está vacío, se muestra una ventana de aviso y no se devuelve ningún usuario.
        /// </returns>
        public void registroUsuario(object parametro)
        {
            AvisoCampoVacioWindow ventanaCampoVacio = new AvisoCampoVacioWindow();

            //Permite almacenar datos (de cualquier tipo) del usuario en un array.
            object[] datosUsuario = { Nombre, Apellido, Rol, Numero, Genero, Correo, Contrasena, ConfirmacionContrasena };

            for (int i = 0; i < datosUsuario.Length; i++)
            {
                if (datosUsuario[i] == null || string.IsNullOrWhiteSpace(datosUsuario[i].ToString()))
                {
                    ventanaCampoVacio.ShowDialog();
                    return;
                }
            }

            if (Contrasena != ConfirmacionContrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            Usuario nuevoUsuario = new Usuario(Nombre, Apellido, Rol, Numero, Genero, Correo, Contrasena);

            DatabaseHelper.iniciarConexion();

            RegistroRepository registroRepository = new RegistroRepository();
            registroRepository.RegistarUsuario(nuevoUsuario);
            MessageBox.Show("Se creó el usuario correctamente.");
           
        }

        /// <summary>
        /// Si el usuario llena todos los campos, podrá registrarse, si deja vacío, no podrá registrarse.
        /// </summary>
        /// <returns> devuelve un true para permitir que la función pueda ejecutarse, devuelve false que no permite ejecutar a la función</returns>
        public bool puedeRegistrarUsuario(object parametro)
        {
            if (string.IsNullOrWhiteSpace(Nombre) ||
                string.IsNullOrWhiteSpace(Apellido) ||
                string.IsNullOrWhiteSpace(Rol) ||
                string.IsNullOrWhiteSpace(Numero) ||
                string.IsNullOrWhiteSpace(Genero) ||
                string.IsNullOrWhiteSpace(Correo) ||
                string.IsNullOrWhiteSpace(Contrasena) ||
                string.IsNullOrWhiteSpace(ConfirmacionContrasena))
            {
                return false;
            }

            return true;
        }
    }
}
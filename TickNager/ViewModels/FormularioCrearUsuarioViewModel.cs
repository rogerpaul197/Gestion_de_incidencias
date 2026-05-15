/// <summary>
/// Esta clase se encarga de la lógica para crear un nuevo usuario.
/// </summary>

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TickNager.Helper;
using TickNager.Models;
using TickNager.Repositories;

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

        public ObservableCollection<string> DepartamentosComboBox { get; set; }

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
            DepartamentosComboBox = new ObservableCollection<string>();
            CargarDepartamentos();
        }

        /// <summary>
        /// Constructor que recibe el ViewModel principal.
        /// </summary>
        /// <param name="obj">ViewModel del dashboard.</param>
        public FormularioCrearUsuarioViewModel(DashboardViewModel obj) : this()
        {
            _obj = obj;
        }

        /// <summary>
        /// Esta función crea un usuario nuevo y lo guarda en la base de datos.
        /// </summary>
        public void CrearUsuario()
        {
            if (Nombre == null || Nombre == "" || Apellido == null || Apellido == "" || Rol == null || Rol == "" || Genero == null || Genero == "" || Departamento == null || Departamento == "" || Departamento == "Seleccione departamento" || Correo == null || Correo == "" || Contrasena == null || Contrasena == "" || ConfirmarContrasena == null || ConfirmarContrasena == "")
            {
                MessageBox.Show("Completa todos los campos obligatorios", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ConfirmarContrasena != Contrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Usuario usuarioNuevo = new Usuario(Nombre, Apellido, Rol, Genero, Departamento, Numero, Correo, Contrasena);

            if (Rol == "Administrador")
            {
                usuarioNuevo.IdRol = 1;
            }
            else if (Rol == "Técnico")
            {
                usuarioNuevo.IdRol = 2;
            }
            else
            {
                usuarioNuevo.IdRol = 3;
            }

            int idDepartamento = UsuarioRepository.ObtenerIdDepartamento(Departamento);

            if (idDepartamento == 0)
            {
                MessageBox.Show("El departamento indicado no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            usuarioNuevo.IdDepartamento = idDepartamento;

            UsuarioRepository.RegistrarUsuario(usuarioNuevo);

            MessageBox.Show("Usuario creado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.None);

            _obj.mostrarVistaGestionUsuarios();
        }

        /// <summary>
        /// Esta función cancela la creación del usuario y vuelve a la gestión de usuarios.
        /// </summary>
        public void Cancelar()
        {
            _obj.mostrarVistaGestionUsuarios();
        }

        /// <summary>
        /// Esta función actualiza la imagen del perfil según el rol y género.
        /// </summary>
        private void ActualizarImagen()
        {
            ImagenPerfil = FuncionesHelper.ObtenerImagenPerfil(Rol, Genero);
        }

        public void CargarDepartamentos()
        {
            DepartamentosComboBox.Clear();

            DepartamentosComboBox.Add("Seleccione departamento");

            var lista = GrupoTrabajoRepository.ObtenerGrupos();

            for (int i = 0; i < lista.Count; i++)
            {
                DepartamentosComboBox.Add(lista[i].NombreDepartamento);
            }

            Departamento = "Seleccione departamento";
        }

        /// <summary>
        /// Evento que avisa a la vista cuando cambia una propiedad.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifica a la vista que una propiedad cambió.
        /// </summary>
        /// <param name="nombrePropiedad">Nombre de la propiedad.</param>
        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
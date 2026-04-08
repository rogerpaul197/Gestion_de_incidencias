using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TickNager.Commands;
using TickNager.Models;
using TickNager.Views.Windows;

namespace TickNager.ViewModels
{
    public class RegistroViewModel : INotifyPropertyChanged
    {
        private string _nombre;
        private string _apellido;
        private string _departamento;
        private string _numero;
        private bool _genero;
        private string _correo;
        private string _contrasena;
        private string _confirmacionContrasena;

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

        public bool Genero
        {
            get => _genero;
            set
            {
                _genero = value;
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
        /// Esta función se encarga de validar que los campos no estén vacíos y luego crea un nuevo usuario con los datos ingresados. Si algún campo está vacío, se muestra una ventana de aviso.
        /// </summary>
        /// <returns>
        /// Deveulve un objeto de tipo Usuario con los datos ingresados por el usuario. Si algún campo está vacío, se muestra una ventana de aviso y no se devuelve ningún usuario.
        /// </returns>
        public void registroUsuario(object parametro)
        {
            AvisoCampoVacioWindow ventanaCampoVacio = new AvisoCampoVacioWindow();

            //Permite almacenar datos (de cualquier tipo) del usuario en un array.
            object[] datosUsuario = { Nombre, Apellido, Departamento, Numero, Correo, Contrasena, ConfirmacionContrasena };
            bool salirBucle = true;

            do
            {
                for (int i = 0; i < datosUsuario.Length; i++)
                {
                    if (datosUsuario[i] == null)
                    {
                        ventanaCampoVacio.Show();
                    }
                    else
                    {
                        salirBucle = false;
                    }
                }
            }
            while (salirBucle);

            Usuario nuevoUsuario = new Usuario(Nombre, Apellido, Numero, Genero, Correo, Contrasena);
            MessageBox.Show("se creo el usuario correctamente");
        }

        /// <summary>
        /// Si el usuario llena todos los campos, podrá registrarse, si deja vacío, no podrá registrarse.
        /// </summary>
        /// <returns> devuelve un true para permitir que la función pueda ejecutarse, devuelve false que no permite ejecutar a la función</returns>
        public bool puedeRegistrarUsuario(object parametro)
        {
            bool puedeEjecutarse = true;
            if (Nombre == null && Apellido == null && Departamento == null && Correo == null && Contrasena == null)
            {
                return !puedeEjecutarse;
            } else
            {
                return puedeEjecutarse;
            }
        }
    }
}
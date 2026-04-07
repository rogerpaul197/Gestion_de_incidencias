using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }

        public Usuario registroUsuario()
        {
            AvisoCampoVacioWindow ventanaCampoVacio = new AvisoCampoVacioWindow();
            object[] verificarDato = { Nombre, Apellido, Departamento, Numero, Correo, Contrasena, ConfirmacionContrasena };

            switch (verificarDato)             {
                case null:
                    ventanaCampoVacio.Show();
                    break;
            }

            Usuario nuevoUsuario = new Usuario(Nombre, Apellido, Departamento, Numero, Correo, Contrasena);
            return nuevoUsuario;
        }
    }
}
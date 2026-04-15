namespace TickNager.Models
{
    public class Usuario
    {
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

        public string RolUsuario
        {
            get { return _rolUsuario; }
            set
            {
                _rolUsuario = value;
            }
        }

        public string GeneroUsuario
        {
            get { return _generoUsuario; }
            set
            {
                _generoUsuario = value;
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

        /// <summary>
        /// Reporta una incidencia
        /// </summary>
        /// <returns>Devuelve una incidencia con descripción</returns>
        /*
        public Incidencia reportarIncidencia()
        {
            bool salirBucle = false;
            string descripcionIncidencia;

            do
            {
                Console.WriteLine("Reporta la incidencia: ");
                descripcionIncidencia = Console.ReadLine();

                if (descripcionIncidencia == null)
                {
                    AvisoCampoVacioWindow ventanaAviso = new AvisoCampoVacioWindow();
                    ventanaAviso.Show();
                    return null;
                }
                else
                {
                    salirBucle = true; //si la descripcion la rellenar el usuario, sale del bucle
                }
            }
            while (!salirBucle);

            Incidencia incidencia = new Incidencia(descripcionIncidencia);
            return incidencia;
        }*/
    }
}
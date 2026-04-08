namespace TickNager.Models
{
    public class Usuario
    {
        private string nombreUsuario { get; set; }
        private string apellidoUsuario { get; set; }
        private string departamentoUsuario;
        private string? numeroUsuario;

        //Se utilizan para poder asignar una imagen masculino o femenino
        private bool esHombre = true;
        private bool esMujer = true;

        private bool generoUsuario;

        private string correoUsuario;
        private string contrasenaUsuario;

        public Usuario()
        {

        }

        public Usuario(string nombreUsuario, string apellidoUsuario, string? numeroUsuario, bool generoUsuario, string correoUsuario, string contrasenaUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.apellidoUsuario = apellidoUsuario;
            this.numeroUsuario = numeroUsuario;
            this.generoUsuario = generoUsuario;
            this.correoUsuario = correoUsuario;
            this.contrasenaUsuario = contrasenaUsuario;
        }

        public Usuario(string nombreUsuario, string apellidoUsuario, string departamentoUsuario, string? numeroUsuario, bool generoUsuario, string correoUsuario, string contrasenaUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.apellidoUsuario = apellidoUsuario;
            this.departamentoUsuario = departamentoUsuario;
            this.numeroUsuario = numeroUsuario;
            this.generoUsuario = generoUsuario;
            this.correoUsuario = correoUsuario;
            this.contrasenaUsuario = contrasenaUsuario;
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

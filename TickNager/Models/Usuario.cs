namespace TickNager.Models
{
    public class Usuario
    {
        private string nombreUsuario { get; set; }
        private string apellidoUsuario { get; set; }
        private string rolUsuario;
        private string? numeroUsuario;

        //Se utilizan para poder asignar una imagen masculino o femenino
        //No hace falta guardar estas variables aquí, porque la imagen se controla desde la ventana de registro según el rol y el género elegidos.

        private string generoUsuario;

        private string correoUsuario;
        private string contrasenaUsuario;

        public Usuario()
        {

        }

        public Usuario(string nombreUsuario, string apellidoUsuario, string? numeroUsuario, string generoUsuario, string correoUsuario, string contrasenaUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.apellidoUsuario = apellidoUsuario;
            this.numeroUsuario = numeroUsuario;
            this.generoUsuario = generoUsuario;
            this.correoUsuario = correoUsuario;
            this.contrasenaUsuario = contrasenaUsuario;
        }

        public Usuario(string nombreUsuario, string apellidoUsuario, string rolUsuario, string? numeroUsuario, string generoUsuario, string correoUsuario, string contrasenaUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.apellidoUsuario = apellidoUsuario;
            this.rolUsuario = rolUsuario;
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
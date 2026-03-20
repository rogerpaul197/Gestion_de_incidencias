using TickNager.Ventanas;

namespace TickNager.Clases
{
    public class Usuario
    {
        public string nombreUsuario;
        public string apellidoUsuario;
<<<<<<< HEAD
        public string departamentoUsuario;
=======
>>>>>>> fa9368ce1a14ebc4361b27f62a1a0a947ee3ab22

        //Se utilizan para poder asignar una imagen masculino o femenino
        public bool esHombre = true;
        public bool esMujer = true;

        public string? numeroUsuario;
        public string correoUsuario;
        public string contrasenaUsuario;
        public Usuario()
        {

        }

<<<<<<< HEAD
        public Usuario(string nombreUsuario, string apellidoUsuario, string departamentoUsuario, string? numeroUsuario, string correoUsuario, string contrasenaUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.apellidoUsuario = apellidoUsuario;
            this.departamentoUsuario = departamentoUsuario;
=======
        public Usuario(string nombreUsuario, string apellidoUsuario, string? numeroUsuario, string correoUsuario, string contrasenaUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.apellidoUsuario = apellidoUsuario;
>>>>>>> fa9368ce1a14ebc4361b27f62a1a0a947ee3ab22
            this.numeroUsuario = numeroUsuario;
            this.correoUsuario = correoUsuario;
            this.contrasenaUsuario = contrasenaUsuario;
        }

        /// <summary>
        /// Reporta una incidencia
        /// </summary>
        /// <returns>Devuelve una incidencia con descripción</returns>
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
<<<<<<< HEAD
                }
                else
=======
                } else
>>>>>>> fa9368ce1a14ebc4361b27f62a1a0a947ee3ab22
                {
                    salirBucle = true; //si la descripcion la rellenar el usuario, sale del bucle
                }
            }
            while (!salirBucle);

            Incidencia incidencia = new Incidencia(descripcionIncidencia);
            return incidencia;
        }
<<<<<<< HEAD

    }
}
=======
        
    }
}
>>>>>>> fa9368ce1a14ebc4361b27f62a1a0a947ee3ab22

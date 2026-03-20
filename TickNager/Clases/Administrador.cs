///<summary>
///Esta clase es la de el administrador, el que se encargará  de gestionar incidencias, usuarios...
///</summary>
using System;
using System.Collections.Generic;
using System.Text;

namespace TickNager.Clases
{
    public class Administrador
    {
        private string nombreAdministrador;
        private string apellidoAdministrador;

        //Se utilizan para poder asignar una imagen masculino o femenino
        public bool esHombre = true;
        public bool esMujer = true;

        private string? numeroAdministrador;
        private string correoAdministrador;
        private string contrasenaAdministrador;

        public Administrador(string nombreAdministrador, string apellidoAdministrador, string? numeroAdministrador, string correoAdministrador, string contrasenaAdministrador)
        {
            this.nombreAdministrador = nombreAdministrador;
            this.apellidoAdministrador = apellidoAdministrador;
            this.numeroAdministrador = numeroAdministrador;
            this.correoAdministrador = correoAdministrador;
            this.contrasenaAdministrador = contrasenaAdministrador;
        }

        /// <summary>
        /// Crea una incidencia
        /// </summary>
        /// <returns>Devuelve una incidencia con datos y asignada --> True</returns>
        public Incidencia asignarIncidencia()
        {
            Console.WriteLine("Introduce la incidencia: ");
            string nombreIncidencia = Console.ReadLine();

            Console.WriteLine("Introduce al técnico o equipo responsable: ");
            string tecnicoResponsable_EquipoResponsable = Console.ReadLine();

            Console.WriteLine("Usuario que reporta la incidencia: ");
            string usuarioResporta = Console.ReadLine();

            Incidencia incidencia = new Incidencia(nombreIncidencia, tecnicoResponsable_EquipoResponsable, usuarioResporta);
            return incidencia;
        }

        /// <summary>
        /// Se usa para poder crear un usuario, dependiendo del rol que le asigne, sérá técnico o un usuario estándar
        /// </summary>
        public void crearUsuario()
        {
            Console.WriteLine("Nombre de usuario: ");
            string nombreUsuario = Console.ReadLine();
            Console.WriteLine("Apellido de usuario: ");
            string apellidoUsuario = Console.ReadLine();
            Console.WriteLine("Rol del usuario (Técnico o usuario estándar): ");
            string rolUsuario = Console.ReadLine();
            Console.WriteLine("Correo del usuario: ");
            string departamentoUsuario = Console.ReadLine();
            Console.WriteLine("Departamento del usuario: ");
            string correoUsuario = Console.ReadLine();
            Console.WriteLine("Contraseña del usuario: ");
            string contrasenaUsuario = Console.ReadLine(); //el administrador le podrá asignar una contraseña al usuario para que use la app, el usuario deberá modificar la contraseña.
            Console.WriteLine("Confirma la contraseña del usuario: ");
            string contrasenaConfirmacionUsuario = Console.ReadLine();
        }

        public void verMisDatos()
        {

        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> fa9368ce1a14ebc4361b27f62a1a0a947ee3ab22

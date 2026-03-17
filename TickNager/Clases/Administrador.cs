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
        public Incidencia crearIncidencia()
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
    }
}

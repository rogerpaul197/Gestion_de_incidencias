///<summary>
///Esta clase es la de el administrador, el que se encargará  de gestionar incidencias, usuarios...
///</summary>
namespace TickNager.Models
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
    }
}

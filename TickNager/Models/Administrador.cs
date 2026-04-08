///<summary>
///Esta clase es la de el administrador, el que se encargará  de gestionar incidencias, usuarios...
///</summary>
namespace TickNager.Models
{
    public class Administrador
    {
        private string nombreAdministrador;
        private string apellidoAdministrador;
        private string departamentoAdministrador;
        private string? numeroAdministrador;
        //Aquí se almacenara todos los usuarios, el método de esto es obtenerUsuario()
        //public ObservableCollection<Usuario> baseDatos = new ObservableCollection<Usuario>;



        //Se utilizan para poder asignar una imagen masculino o femenino
        private bool esHombre = true;
        private bool esMujer = true;

        private bool  generoAdministrador;

        private string correoAdministrador;
        private string contrasenaAdministrador;

        public Administrador(string nombreAdministrador, string apellidoAdministrador, string? numeroAdministrador, bool generoAdministrador, string correoAdministrador, string contrasenaAdministrador)
        {
            this.nombreAdministrador = nombreAdministrador;
            this.apellidoAdministrador = apellidoAdministrador;
            this.numeroAdministrador = numeroAdministrador;
            this.generoAdministrador = generoAdministrador;
            this.correoAdministrador = correoAdministrador;
            this.contrasenaAdministrador = contrasenaAdministrador;
        }

        public Administrador(string nombreAdministrador, string apellidoAdministrador, string departamentoAdministrador, string? numeroAdministrador, bool generoAdministrador, string correoAdministrador, string contrasenaAdministrador)
        {
            this.nombreAdministrador = nombreAdministrador;
            this.apellidoAdministrador = apellidoAdministrador;
            this.departamentoAdministrador = departamentoAdministrador;
            this.numeroAdministrador = numeroAdministrador;
            this.generoAdministrador = generoAdministrador;
            this.correoAdministrador = correoAdministrador;
            this.contrasenaAdministrador = contrasenaAdministrador;
        }

        /*
        public static ObservableCollection<Usuario> obtenerUsuarios()
        {
            return baseDatos;
        }*/

        /*
        public static void anadirUsuario(Usuario usuario)
        {
            baseDatos.Add(usuario);
        }*/
    }
}

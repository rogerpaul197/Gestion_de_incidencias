using TickNager.Helper;
using TickNager.Models;

///<summary>
///Aquí van las operaciones CRUD
///</summary>
namespace TickNager.Repositories
{
    public class UsuarioRepository
    {
        public UsuarioRepository()
        {
        }

        //Insert
        public static void RegistarUsuario(Usuario usuario)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"INSERT INTO usuarios 
                                    (nombre, apellido, rol, numero, genero, correo, contrasena)
                                    VALUES 
                                    (@nombre, @apellido, @rol, @numero, @genero, @correo, @contrasena)";

            comando.Parameters.AddWithValue("@nombre", usuario.NombreUsuario);
            comando.Parameters.AddWithValue("@apellido", usuario.ApellidoUsuario);
            comando.Parameters.AddWithValue("@rol", usuario.RolUsuario);
            comando.Parameters.AddWithValue("@numero", usuario.NumeroUsuario);
            comando.Parameters.AddWithValue("@genero", usuario.GeneroUsuario);
            comando.Parameters.AddWithValue("@correo", usuario.CorreoUsuario);
            comando.Parameters.AddWithValue("@contrasena", usuario.ContrasenaUsuario);
            comando.ExecuteNonQuery();
        }

        //Select, esto lo usaré para el login, para verificar que el correo y la contraseña sean correctos.
        public static bool VerificarUsuario(string correo, string contrasena)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) 
                                    FROM usuarios 
                                    WHERE correo = @correo AND contrasena = @contrasena";

            comando.Parameters.AddWithValue("@correo", correo);
            comando.Parameters.AddWithValue("@contrasena", contrasena);

            long resultado = (long)comando.ExecuteScalar();

            return resultado > 0;
        }
    }
}

using TickNager.Helper;
using TickNager.Models;

///<summary>
///Aquí van las operaciones CRUD
///usaré funciones estáticas para llamarlas directamente con la clase.
///Los usaré en los ViewModels.
///</summary>
namespace TickNager.Repositories
{
    public class UsuarioRepository
    {
        public UsuarioRepository()
        {
        }

        /// <summary>
        /// Este método registra un usuario a la base de datos.
        /// </summary>
        /// <param name="usuario"></param>
        public static void RegistrarUsuario(Usuario usuario)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"INSERT INTO usuarios 
                                    (nombre, apellido, rol, genero, departamento, numero, correo, contrasena)
                                    VALUES 
                                    (@nombre, @apellido, @rol, @genero, @departamento, @numero, @correo, @contrasena)";

            comando.Parameters.AddWithValue("@nombre", usuario.NombreUsuario);
            comando.Parameters.AddWithValue("@apellido", usuario.ApellidoUsuario);
            comando.Parameters.AddWithValue("@rol", usuario.RolUsuario);
            comando.Parameters.AddWithValue("@genero", usuario.GeneroUsuario);
            comando.Parameters.AddWithValue("@departamento", usuario.Departamento);
            comando.Parameters.AddWithValue("@numero", usuario.NumeroUsuario);
            comando.Parameters.AddWithValue("@correo", usuario.CorreoUsuario);
            string passwordHasheado = HashPasswordHelper.HashPassword(usuario.ContrasenaUsuario);
            comando.Parameters.AddWithValue("@contrasena", passwordHasheado);
            comando.ExecuteNonQuery();
        }

        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT nombre, apellido, rol, genero, departamento, numero, correo, contrasena
                            FROM usuarios";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Usuario usuario = new Usuario
                {
                    NombreUsuario = reader["nombre"].ToString(),
                    ApellidoUsuario = reader["apellido"].ToString(),
                    RolUsuario = reader["rol"].ToString(),
                    GeneroUsuario = reader["genero"].ToString(),
                    Departamento = reader["departamento"].ToString(),
                    NumeroUsuario = reader["numero"].ToString(),
                    CorreoUsuario = reader["correo"].ToString(),
                    ContrasenaUsuario = reader["contrasena"].ToString()
                };

                listaUsuarios.Add(usuario);
            }

            return listaUsuarios;
        }

        /// <summary>
        /// sirve para verificar si el correo ya existe en la base de datos, esto es para evitar que se registren dos usuarios con el mismo correo.
        /// </summary>
        /// <param name="correo">El correo electrónico a verificar.</param>
        /// <returns>True si el correo ya existe, false en caso contrario.</returns>
        private static void CorreoYaExiste(string correo)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) 
                                    FROM usuarios 
                                    WHERE correo = @correo";

            comando.Parameters.AddWithValue("@correo", correo);

            long resultado = (long)comando.ExecuteScalar();

        }

        /// <summary>
        /// Select, esto lo usaré para el login, para verificar que el correo y la contraseña sean correctos.
        /// </summary>
        /// <param name="correo">El correo electrónico del usuario.</param>
        /// <param name="contrasena">La contraseña del usuario.</param>
        /// <returns>True si el correo y la contraseña son correctos, false en caso contrario.</returns>
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

        public static int ObtenerTotalUsuarios()
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) FROM usuarios";

            long resultado = (long)comando.ExecuteScalar();

            return (int)resultado;
        }

        public static Usuario ObtenerUsuarioPorCredenciales(string correo, string contrasena)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT id, nombre, apellido, rol, genero, departamento, numero, correo, contrasena
                    FROM usuarios
                    WHERE correo = @correo AND contrasena = @contrasena
                    LIMIT 1";

            comando.Parameters.AddWithValue("@correo", correo);
            comando.Parameters.AddWithValue("@contrasena", contrasena);

            using var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                Usuario usuario = new Usuario
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    NombreUsuario = reader["nombre"].ToString(),
                    ApellidoUsuario = reader["apellido"].ToString(),
                    RolUsuario = reader["rol"].ToString(),
                    GeneroUsuario = reader["genero"].ToString(),
                    Departamento = reader["departamento"].ToString(),
                    NumeroUsuario = reader["numero"].ToString(),
                    CorreoUsuario = reader["correo"].ToString(),
                    ContrasenaUsuario = reader["contrasena"].ToString()
                };

                return usuario;
            }

            return null;
        }
    }
}
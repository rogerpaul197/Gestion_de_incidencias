///<summary>
///Aquí van las operaciones CRUD.
///Usaré funciones estáticas para llamarlas directamente con la clase.
///Los usaré en los ViewModels.
///</summary>

using TickNager.Helper;
using TickNager.Models;

namespace TickNager.Repositories
{
    public class UsuarioRepository
    {
        /// <summary>
        /// Constructor vacío de la clase UsuarioRepository.
        /// </summary>
        public UsuarioRepository()
        {
        }

        /// <summary>
        /// Esta función se encarga de registrar un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">Usuario que se va a registrar.</param>
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

        /// <summary>
        /// Esta función obtiene todos los usuarios registrados en la base de datos.
        /// </summary>
        /// <returns>Devuelve una lista con todos los usuarios.</returns>
        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT id, nombre, apellido, rol, genero, departamento, numero, correo, contrasena
                                    FROM usuarios";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Usuario usuario = new Usuario();

                usuario.Id = reader.GetInt32(reader.GetOrdinal("id"));
                usuario.NombreUsuario = reader["nombre"].ToString();
                usuario.ApellidoUsuario = reader["apellido"].ToString();
                usuario.RolUsuario = reader["rol"].ToString();
                usuario.GeneroUsuario = reader["genero"].ToString();
                usuario.Departamento = reader["departamento"].ToString();
                usuario.NumeroUsuario = reader["numero"].ToString();
                usuario.CorreoUsuario = reader["correo"].ToString();
                usuario.ContrasenaUsuario = reader["contrasena"].ToString();

                listaUsuarios.Add(usuario);
            }

            return listaUsuarios;
        }

        /// <summary>
        /// Esta función comprueba si un correo ya existe en la base de datos.
        /// </summary>
        /// <param name="correo">Correo que se va a buscar en la base de datos.</param>
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
        /// Esta función verifica si existe un usuario con el correo y contraseña indicados.
        /// </summary>
        /// <param name="correo">Correo del usuario.</param>
        /// <param name="contrasena">Contraseña del usuario.</param>
        /// <returns>Devuelve true si el usuario existe, si no existe, devuelve false.</returns>
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

        /// <summary>
        /// Esta función obtiene el número total de usuarios registrados.
        /// </summary>
        /// <returns>Devuelve la cantidad total de usuarios.</returns>
        public static int ObtenerTotalUsuarios()
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) FROM usuarios";

            long resultado = (long)comando.ExecuteScalar();

            return (int)resultado;
        }

        /// <summary>
        /// Esta función obtiene un usuario según su correo y contraseña.
        /// </summary>
        /// <param name="correo">Correo del usuario.</param>
        /// <param name="contrasena">Contraseña del usuario, ya hasheada.</param>
        /// <returns>Devuelve el usuario encontrado. Si no existe, devuelve null.</returns>
        public static Usuario ObtenerUsuarioCredenciales(string correo, string contrasena)
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
                Usuario usuario = new Usuario();

                usuario.Id = reader.GetInt32(reader.GetOrdinal("id"));
                usuario.NombreUsuario = reader["nombre"].ToString();
                usuario.ApellidoUsuario = reader["apellido"].ToString();
                usuario.RolUsuario = reader["rol"].ToString();
                usuario.GeneroUsuario = reader["genero"].ToString();
                usuario.Departamento = reader["departamento"].ToString();
                usuario.NumeroUsuario = reader["numero"].ToString();
                usuario.CorreoUsuario = reader["correo"].ToString();
                usuario.ContrasenaUsuario = reader["contrasena"].ToString();

                return usuario;
            }

            return null;
        }

        /// <summary>
        /// Esta función cambia la contraseña de un usuario.
        /// </summary>
        /// <param name="idUsuario">Id del usuario al que se le cambiará la contraseña.</param>
        /// <param name="contrasenaNueva">Nueva contraseña del usuario, ya hasheada.</param>
        public static void CambiarContrasena(int idUsuario, string contrasenaNueva)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"UPDATE usuarios
                                    SET contrasena = @contrasena
                                    WHERE id = @id";

            comando.Parameters.AddWithValue("@contrasena", contrasenaNueva);
            comando.Parameters.AddWithValue("@id", idUsuario);

            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Esta función actualiza los datos principales de un usuario.
        /// </summary>
        /// <param name="usuario">Usuario con los datos actualizados.</param>
        public static void ActualizarUsuario(Usuario usuario)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"UPDATE usuarios 
                                    SET nombre = @nombre,
                                    apellido = @apellido,
                                    correo = @correo,
                                    departamento = @departamento
                                    WHERE id = @id";

            comando.Parameters.AddWithValue("@nombre", usuario.NombreUsuario);
            comando.Parameters.AddWithValue("@apellido", usuario.ApellidoUsuario);
            comando.Parameters.AddWithValue("@correo", usuario.CorreoUsuario);
            comando.Parameters.AddWithValue("@departamento", usuario.Departamento);
            comando.Parameters.AddWithValue("@id", usuario.Id);

            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Esta función obtiene todos los usuarios que tienen rol de administrador.
        /// </summary>
        /// <returns>Devuelve una lista con los usuarios administradores.</returns>
        public static List<Usuario> ObtenerAdministradores()
        {
            List<Usuario> administradores = new List<Usuario>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT id, nombre, apellido, rol, genero, departamento, numero, correo, contrasena
                                    FROM usuarios
                                    WHERE rol = 'Administrador'";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Usuario usuario = new Usuario();

                usuario.Id = reader.GetInt32(reader.GetOrdinal("id"));
                usuario.NombreUsuario = reader["nombre"].ToString();
                usuario.ApellidoUsuario = reader["apellido"].ToString();
                usuario.RolUsuario = reader["rol"].ToString();
                usuario.GeneroUsuario = reader["genero"].ToString();
                usuario.Departamento = reader["departamento"].ToString();
                usuario.NumeroUsuario = reader["numero"].ToString();
                usuario.CorreoUsuario = reader["correo"].ToString();
                usuario.ContrasenaUsuario = reader["contrasena"].ToString();

                administradores.Add(usuario);
            }

            return administradores;
        }
    }
}
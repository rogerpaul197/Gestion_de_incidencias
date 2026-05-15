///<summary>
///Aquí van las operaciones CRUD.
///Usaré funciones estáticas para llamarlas directamente con la clase.
///Los usaré en los ViewModels.
///</summary>

using System;
using System.Windows;
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
                                    (nombre, apellido, genero, numero, correo, contrasena, id_rol, id_departamento)
                                    VALUES 
                                    (@nombre, @apellido, @genero, @numero, @correo, @contrasena, @id_rol, @id_departamento)";

            comando.Parameters.AddWithValue("@nombre", usuario.NombreUsuario);
            comando.Parameters.AddWithValue("@apellido", usuario.ApellidoUsuario);
            comando.Parameters.AddWithValue("@genero", usuario.GeneroUsuario);
            comando.Parameters.AddWithValue("@numero", usuario.NumeroUsuario);
            comando.Parameters.AddWithValue("@correo", usuario.CorreoUsuario);

            string passwordHasheado = HashPasswordHelper.HashPassword(usuario.ContrasenaUsuario);
            comando.Parameters.AddWithValue("@contrasena", passwordHasheado);

            comando.Parameters.AddWithValue("@id_rol", usuario.IdRol);
            comando.Parameters.AddWithValue("@id_departamento", usuario.IdDepartamento);

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
            comando.CommandText = @"SELECT usuarios.id_usuario,
                                           usuarios.nombre,
                                           usuarios.apellido,
                                           usuarios.genero,
                                           usuarios.numero,
                                           usuarios.correo,
                                           usuarios.contrasena,
                                           usuarios.id_rol,
                                           usuarios.id_departamento,
                                           roles.nombre AS rol,
                                           departamentos.nombre AS departamento
                                    FROM usuarios
                                    INNER JOIN roles ON usuarios.id_rol = roles.id_rol
                                    INNER JOIN departamentos ON usuarios.id_departamento = departamentos.id_departamento";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Usuario usuario = new Usuario();

                usuario.Id = reader.GetInt32(reader.GetOrdinal("id_usuario"));
                usuario.NombreUsuario = reader["nombre"].ToString();
                usuario.ApellidoUsuario = reader["apellido"].ToString();
                usuario.GeneroUsuario = reader["genero"].ToString();
                usuario.NumeroUsuario = reader["numero"].ToString();
                usuario.CorreoUsuario = reader["correo"].ToString();
                usuario.ContrasenaUsuario = reader["contrasena"].ToString();
                usuario.IdRol = reader.GetInt32(reader.GetOrdinal("id_rol"));
                usuario.IdDepartamento = reader.GetInt32(reader.GetOrdinal("id_departamento"));
                usuario.RolUsuario = reader["rol"].ToString();
                usuario.Departamento = reader["departamento"].ToString();

                listaUsuarios.Add(usuario);
            }

            return listaUsuarios;
        }

        /// <summary>
        /// Esta función comprueba si un correo ya existe en la base de datos.
        /// </summary>
        /// <param name="correo">Correo que se va a buscar en la base de datos.</param>
        private static bool CorreoYaExiste(string correo)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) 
                                    FROM usuarios 
                                    WHERE correo = @correo";

            comando.Parameters.AddWithValue("@correo", correo);

            long resultado = (long)comando.ExecuteScalar();

            return resultado > 0;
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
            comando.CommandText = @"SELECT usuarios.id_usuario,
                                           usuarios.nombre,
                                           usuarios.apellido,
                                           usuarios.genero,
                                           usuarios.numero,
                                           usuarios.correo,
                                           usuarios.contrasena,
                                           usuarios.id_rol,
                                           usuarios.id_departamento,
                                           roles.nombre AS rol,
                                           departamentos.nombre AS departamento
                                    FROM usuarios
                                    INNER JOIN roles ON usuarios.id_rol = roles.id_rol
                                    INNER JOIN departamentos ON usuarios.id_departamento = departamentos.id_departamento
                                    WHERE usuarios.correo = @correo AND usuarios.contrasena = @contrasena
                                    LIMIT 1";

            comando.Parameters.AddWithValue("@correo", correo);
            comando.Parameters.AddWithValue("@contrasena", contrasena);

            using var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                Usuario usuario = new Usuario();

                usuario.Id = reader.GetInt32(reader.GetOrdinal("id_usuario"));
                usuario.NombreUsuario = reader["nombre"].ToString();
                usuario.ApellidoUsuario = reader["apellido"].ToString();
                usuario.GeneroUsuario = reader["genero"].ToString();
                usuario.NumeroUsuario = reader["numero"].ToString();
                usuario.CorreoUsuario = reader["correo"].ToString();
                usuario.ContrasenaUsuario = reader["contrasena"].ToString();
                usuario.IdRol = reader.GetInt32(reader.GetOrdinal("id_rol"));
                usuario.IdDepartamento = reader.GetInt32(reader.GetOrdinal("id_departamento"));
                usuario.RolUsuario = reader["rol"].ToString();
                usuario.Departamento = reader["departamento"].ToString();

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
                                    WHERE id_usuario = @id_usuario";

            comando.Parameters.AddWithValue("@contrasena", contrasenaNueva);
            comando.Parameters.AddWithValue("@id_usuario", idUsuario);

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
                                    id_departamento = @id_departamento
                                    WHERE id_usuario = @id_usuario";

            comando.Parameters.AddWithValue("@nombre", usuario.NombreUsuario);
            comando.Parameters.AddWithValue("@apellido", usuario.ApellidoUsuario);
            comando.Parameters.AddWithValue("@correo", usuario.CorreoUsuario);
            comando.Parameters.AddWithValue("@id_departamento", usuario.IdDepartamento);
            comando.Parameters.AddWithValue("@id_usuario", usuario.Id);

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
            comando.CommandText = @"SELECT usuarios.id_usuario,
                                           usuarios.nombre,
                                           usuarios.apellido,
                                           usuarios.genero,
                                           usuarios.numero,
                                           usuarios.correo,
                                           usuarios.contrasena,
                                           usuarios.id_rol,
                                           usuarios.id_departamento,
                                           roles.nombre AS rol,
                                           departamentos.nombre AS departamento
                                    FROM usuarios
                                    INNER JOIN roles ON usuarios.id_rol = roles.id_rol
                                    INNER JOIN departamentos ON usuarios.id_departamento = departamentos.id_departamento
                                    WHERE roles.nombre = 'Administrador'";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Usuario administrador = new Usuario();

                administrador.Id = reader.GetInt32(reader.GetOrdinal("id_usuario"));
                administrador.NombreUsuario = reader["nombre"].ToString();
                administrador.ApellidoUsuario = reader["apellido"].ToString();
                administrador.GeneroUsuario = reader["genero"].ToString();
                administrador.NumeroUsuario = reader["numero"].ToString();
                administrador.CorreoUsuario = reader["correo"].ToString();
                administrador.ContrasenaUsuario = reader["contrasena"].ToString();
                administrador.IdRol = reader.GetInt32(reader.GetOrdinal("id_rol"));
                administrador.IdDepartamento = reader.GetInt32(reader.GetOrdinal("id_departamento"));
                administrador.RolUsuario = reader["rol"].ToString();
                administrador.Departamento = reader["departamento"].ToString();

                administradores.Add(administrador);
            }

            return administradores;
        }

        /// <summary>
        /// Esta función obtiene todos los usuarios que tienen rol de técnico.
        /// </summary>
        /// <returns>Devuelve una lista con todos los técnicos.</returns>
        public static List<Usuario> ObtenerTecnicos()
        {
            List<Usuario> listaTecnicos = new List<Usuario>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT usuarios.id_usuario,
                                   usuarios.nombre,
                                   usuarios.apellido,
                                   usuarios.genero,
                                   usuarios.numero,
                                   usuarios.correo,
                                   usuarios.contrasena,
                                   usuarios.id_rol,
                                   usuarios.id_departamento,
                                   roles.nombre AS rol,
                                   departamentos.nombre AS departamento
                            FROM usuarios
                            INNER JOIN roles ON usuarios.id_rol = roles.id_rol
                            INNER JOIN departamentos ON usuarios.id_departamento = departamentos.id_departamento
                            WHERE roles.nombre = 'Técnico'";


            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Usuario tecnico = new Usuario();

                tecnico.Id = reader.GetInt32(reader.GetOrdinal("id_usuario"));
                tecnico.NombreUsuario = reader["nombre"].ToString();
                tecnico.ApellidoUsuario = reader["apellido"].ToString();
                tecnico.GeneroUsuario = reader["genero"].ToString();
                tecnico.NumeroUsuario = reader["numero"].ToString();
                tecnico.CorreoUsuario = reader["correo"].ToString();
                tecnico.ContrasenaUsuario = reader["contrasena"].ToString();
                tecnico.IdRol = reader.GetInt32(reader.GetOrdinal("id_rol"));
                tecnico.IdDepartamento = reader.GetInt32(reader.GetOrdinal("id_departamento"));
                tecnico.RolUsuario = reader["rol"].ToString();
                tecnico.Departamento = reader["departamento"].ToString();

                listaTecnicos.Add(tecnico);
            }

            return listaTecnicos;
        }

        /// <summary>
        /// Esta función asigna un técnico a una incidencia y cambia su estado a Asignada.
        /// </summary>
        /// <param name="idIncidencia">Id de la incidencia que se va a asignar.</param>
        /// <param name="idTecnico">Id del técnico que será asignado.</param>
        public static void AsignarTecnico(int idIncidencia, int idTecnico)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"UPDATE incidencias
                                    SET id_tecnico = @id_tecnico,
                                    estado = 'Asignada'
                                    WHERE id_incidencia = @id_incidencia";

            comando.Parameters.AddWithValue("@id_tecnico", idTecnico);
            comando.Parameters.AddWithValue("@id_incidencia", idIncidencia);

            comando.ExecuteNonQuery();

            NotificacionRepository.CrearNotificacion(idTecnico, "Te han asignado una nueva incidencia.");
        }

        /// <summary>
        /// Esta función cambia el rol de un usuario.
        /// </summary>
        /// <param name="idUsuario">Id del usuario al que se le cambiará el rol.</param>
        /// <param name="nuevoRol">Nuevo rol que tendrá el usuario.</param>
        public static void CambiarRolUsuario(int idUsuario, string nuevoRol)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comandoRol = conexion.CreateCommand();
            comandoRol.CommandText = @"SELECT id_rol
                                        FROM roles
                                        WHERE nombre = @nombre";

            comandoRol.Parameters.AddWithValue("@nombre", nuevoRol);

            object resultado = comandoRol.ExecuteScalar();

            int idRol = 0;

            if (resultado != null && resultado != DBNull.Value)
            {
                idRol = Convert.ToInt32(resultado);
            }

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"UPDATE usuarios
                                    SET id_rol = @id_rol
                                    WHERE id_usuario = @id_usuario";

            comando.Parameters.AddWithValue("@id_rol", idRol);
            comando.Parameters.AddWithValue("@id_usuario", idUsuario);

            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Esta función elimina un usuario de la base de datos.
        /// </summary>
        /// <param name="idUsuario">Id del usuario que se va a eliminar.</param>
        public static void EliminarUsuario(int idUsuario)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"DELETE FROM usuarios
                                    WHERE id_usuario = @id_usuario";

            comando.Parameters.AddWithValue("@id_usuario", idUsuario);

            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Esta función obtiene el id de un departamento según su nombre.
        /// </summary>
        /// <param name="nombreDepartamento">Nombre del departamento.</param>
        /// <returns>Devuelve el id del departamento. Si no existe, devuelve 0.</returns>
        public static int ObtenerIdDepartamento(string nombreDepartamento)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT id_departamento
                            FROM departamentos
                            WHERE nombre = @nombre";

            comando.Parameters.AddWithValue("@nombre", nombreDepartamento);

            object resultado = comando.ExecuteScalar();

            if (resultado == null || resultado == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(resultado);
        }
    }
}
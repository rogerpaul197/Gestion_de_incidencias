/// <summary>
/// Esta clase contiene las operaciones que puede realizar el administrador en la base de datos.
/// </summary>

using TickNager.Helper;

namespace TickNager.Repositories
{
    public class AdministradorRepository
    {
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
                                    WHERE id = @id";

            comando.Parameters.AddWithValue("@id_tecnico", idTecnico);
            comando.Parameters.AddWithValue("@id", idIncidencia);

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

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"UPDATE usuarios
                                    SET rol = @rol
                                    WHERE id = @id";

            comando.Parameters.AddWithValue("@rol", nuevoRol);
            comando.Parameters.AddWithValue("@id", idUsuario);

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
                                    WHERE id = @id";

            comando.Parameters.AddWithValue("@id", idUsuario);

            comando.ExecuteNonQuery();
        }
    }
}
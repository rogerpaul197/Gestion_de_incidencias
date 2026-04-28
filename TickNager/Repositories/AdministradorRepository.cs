using TickNager.Helper;

namespace TickNager.Repositories
{
    public class AdministradorRepository
    {
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
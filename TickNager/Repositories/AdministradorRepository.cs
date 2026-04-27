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
        }
    }
}
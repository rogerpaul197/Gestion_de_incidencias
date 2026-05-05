using System.Collections.Generic;
using TickNager.Helper;
using TickNager.Models;

namespace TickNager.Repositories
{
    public class GrupoTrabajoRepository
    {
        public static void CrearGrupo(string nombre)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"INSERT INTO departamentos
                                    (nombre)
                                    VALUES
                                    (@nombre)";

            comando.Parameters.AddWithValue("@nombre", nombre);

            comando.ExecuteNonQuery();
        }

        public static List<GrupoTrabajo> ObtenerGrupos()
        {
            List<GrupoTrabajo> grupos = new List<GrupoTrabajo>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT d.id, d.nombre, COUNT(u.id) AS cantidad
                                    FROM departamentos d
                                    LEFT JOIN usuarios u ON u.departamento = d.nombre
                                    GROUP BY d.id, d.nombre";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                GrupoTrabajo grupo = new GrupoTrabajo();

                grupo.Id = reader.GetInt32(reader.GetOrdinal("id"));
                grupo.NombreDepartamento = reader["nombre"].ToString();
                grupo.CantidadMiembros = reader.GetInt32(reader.GetOrdinal("cantidad"));

                grupos.Add(grupo);
            }

            return grupos;
        }

        public static void RenombrarGrupo(int idGrupo, string nombreAnterior, string nombreNuevo)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"UPDATE departamentos
                                    SET nombre = @nombreNuevo
                                    WHERE id = @id";

            comando.Parameters.AddWithValue("@nombreNuevo", nombreNuevo);
            comando.Parameters.AddWithValue("@id", idGrupo);

            comando.ExecuteNonQuery();

            using var comandoUsuarios = conexion.CreateCommand();
            comandoUsuarios.CommandText = @"UPDATE usuarios
                                            SET departamento = @nombreNuevo
                                            WHERE departamento = @nombreAnterior";

            comandoUsuarios.Parameters.AddWithValue("@nombreNuevo", nombreNuevo);
            comandoUsuarios.Parameters.AddWithValue("@nombreAnterior", nombreAnterior);

            comandoUsuarios.ExecuteNonQuery();
        }

        public static void EliminarGrupo(int idGrupo, string nombreGrupo)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comandoUsuarios = conexion.CreateCommand();
            comandoUsuarios.CommandText = @"UPDATE usuarios
                                            SET departamento = ''
                                            WHERE departamento = @nombreGrupo";

            comandoUsuarios.Parameters.AddWithValue("@nombreGrupo", nombreGrupo);
            comandoUsuarios.ExecuteNonQuery();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"DELETE FROM departamentos
                                    WHERE id = @id";

            comando.Parameters.AddWithValue("@id", idGrupo);

            comando.ExecuteNonQuery();
        }

        public static void AsignarUsuarioAGrupo(int idUsuario, string nombreGrupo)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"UPDATE usuarios
                            SET departamento = @departamento
                            WHERE id = @id";

            comando.Parameters.AddWithValue("@departamento", nombreGrupo);
            comando.Parameters.AddWithValue("@id", idUsuario);

            comando.ExecuteNonQuery();
        }
    }
}
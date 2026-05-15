using System;
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
            comando.CommandText = @"SELECT departamentos.id_departamento, departamentos.nombre, COUNT(usuarios.id_usuario) AS cantidad
                                    FROM departamentos
                                    LEFT JOIN usuarios ON usuarios.id_departamento = departamentos.id_departamento
                                    GROUP BY departamentos.id_departamento, departamentos.nombre";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                GrupoTrabajo grupo = new GrupoTrabajo();

                grupo.Id = reader.GetInt32(reader.GetOrdinal("id_departamento"));
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
                                    WHERE id_departamento = @id_departamento";

            comando.Parameters.AddWithValue("@nombreNuevo", nombreNuevo);
            comando.Parameters.AddWithValue("@id_departamento", idGrupo);

            comando.ExecuteNonQuery();
        }

        public static void EliminarGrupo(int idGrupo, string nombreGrupo)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comandoUsuarios = conexion.CreateCommand();
            comandoUsuarios.CommandText = @"UPDATE usuarios
                                            SET id_departamento = 0
                                            WHERE id_departamento = @id_departamento";

            comandoUsuarios.Parameters.AddWithValue("@id_departamento", idGrupo);
            comandoUsuarios.ExecuteNonQuery();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"DELETE FROM departamentos
                                    WHERE id_departamento = @id_departamento";

            comando.Parameters.AddWithValue("@id_departamento", idGrupo);
            comando.ExecuteNonQuery();
        }

        public static void AsignarUsuarioAGrupo(int idUsuario, string nombreGrupo)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comandoDepartamento = conexion.CreateCommand();
            comandoDepartamento.CommandText = @"SELECT id_departamento
                                        FROM departamentos
                                        WHERE nombre = @nombre";

            comandoDepartamento.Parameters.AddWithValue("@nombre", nombreGrupo);

            object resultado = comandoDepartamento.ExecuteScalar();

            int idDepartamento = 0;

            if (resultado != null && resultado != DBNull.Value)
            {
                idDepartamento = Convert.ToInt32(resultado);
            }

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"UPDATE usuarios
                            SET id_departamento = @id_departamento
                            WHERE id_usuario = @id_usuario";

            comando.Parameters.AddWithValue("@id_departamento", idDepartamento);
            comando.Parameters.AddWithValue("@id_usuario", idUsuario);

            comando.ExecuteNonQuery();
        }
    }
}
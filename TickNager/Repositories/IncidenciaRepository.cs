using System;
using System.Collections.Generic;
using System.Text;
using TickNager.Helper;
using TickNager.Models;

namespace TickNager.Repositories
{
    public class IncidenciaRepository
    {
        /// <summary>
        /// Esto se usará para el formulario de registro de incidencias.
        /// </summary>
        /// <param name="usuario"></param>
        public static void RegistrarIncidencia(Incidencia incidencia)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"INSERT INTO incidencias 
                        (titulo, descripcion, categoria, prioridad, fecha_creacion)
                        VALUES 
                        (@titulo, @descripcion, @categoria, @prioridad, @fecha_creacion)";

            comando.Parameters.AddWithValue("@titulo", incidencia.Titulo);
            comando.Parameters.AddWithValue("@descripcion", incidencia.Descripcion);
            comando.Parameters.AddWithValue("@categoria", incidencia.Categoria);
            comando.Parameters.AddWithValue("@prioridad", incidencia.Prioridad);
            comando.Parameters.AddWithValue("@fecha_creacion", DateTime.Now.ToString("yyyy-MM-dd"));
            comando.ExecuteNonQuery();
        }

        public static List<Incidencia> ObtenerIncidencias()
        {
            List<Incidencia> listaIncidencias = new List<Incidencia>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT titulo, descripcion, categoria, prioridad, fecha_creacion
                            FROM incidencias";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Incidencia incidencia = new Incidencia
                {
                    Titulo = reader["titulo"].ToString(),
                    Descripcion = reader["descripcion"].ToString(),
                    Categoria = reader["categoria"].ToString(),
                    Prioridad = reader["prioridad"].ToString()
                };

                if (reader["fecha_creacion"] != DBNull.Value)
                {
                    incidencia.AsignarFechaRegistro(DateTime.Parse(reader["fecha_creacion"].ToString()));
                }

                listaIncidencias.Add(incidencia);
            }

            return listaIncidencias;
        }

        public static int ObtenerTotalIncidencias()
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) FROM incidencias";

            long resultado = (long)comando.ExecuteScalar();

            return (int)resultado;
        }

        public static int ObtenerIncidenciasPendientes()
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) 
                            FROM incidencias
                            WHERE estado IS NULL OR estado = 0";

            long resultado = (long)comando.ExecuteScalar();

            return (int)resultado;
        }

        public static int ObtenerIncidenciasEnProceso()
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) 
                            FROM incidencias
                            WHERE estado = 1";

            long resultado = (long)comando.ExecuteScalar();

            return (int)resultado;
        }

        public static int ObtenerIncidenciasPorPrioridad(string prioridad)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) 
                            FROM incidencias 
                            WHERE prioridad = @prioridad";

            comando.Parameters.AddWithValue("@prioridad", prioridad);

            long resultado = (long)comando.ExecuteScalar();

            return (int)resultado;
        }

        public static int ObtenerIncidenciasPorEstado(int estado)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) 
                            FROM incidencias 
                            WHERE estado = @estado";

            comando.Parameters.AddWithValue("@estado", estado);

            long resultado = (long)comando.ExecuteScalar();

            return (int)resultado;
        }

        public static int ObtenerIncidenciasPendientesGrafico()
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) 
                            FROM incidencias 
                            WHERE estado IS NULL OR estado = 0";

            long resultado = (long)comando.ExecuteScalar();

            return (int)resultado;
        }

        public static Dictionary<string, int> ObtenerIncidenciasPorFecha()
        {
            Dictionary<string, int> datos = new Dictionary<string, int>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT fecha_creacion, COUNT(*) AS cantidad
                            FROM incidencias
                            WHERE fecha_creacion IS NOT NULL
                            GROUP BY fecha_creacion
                            ORDER BY fecha_creacion";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                string fecha = reader["fecha_creacion"].ToString();
                int cantidad = reader.GetInt32(reader.GetOrdinal("cantidad"));

                datos.Add(fecha, cantidad);
            }

            return datos;
        }
    }
}

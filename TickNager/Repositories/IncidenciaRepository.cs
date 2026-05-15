/// <summary>
/// Esta clase contiene las operaciones relacionadas con las incidencias en la base de datos.
/// </summary>

using System;
using System.Collections.Generic;
using TickNager.Helper;
using TickNager.Models;

namespace TickNager.Repositories
{
    public class IncidenciaRepository
    {
        /// <summary>
        /// Esto se usará para el formulario de registro de incidencias.
        /// </summary>
        /// <param name="incidencia">Incidencia que se va a registrar.</param>
        public static void RegistrarIncidencia(Incidencia incidencia)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"INSERT INTO incidencias 
                                    (titulo, descripcion, prioridad, estado, fecha_creacion, id_reportero, id_tecnico, id_categoria)
                                    VALUES 
                                    (@titulo, @descripcion, @prioridad, @estado, @fecha_creacion, @id_reportero, @id_tecnico, @id_categoria)";

            comando.Parameters.AddWithValue("@titulo", incidencia.Titulo);
            comando.Parameters.AddWithValue("@descripcion", incidencia.Descripcion);
            comando.Parameters.AddWithValue("@prioridad", incidencia.Prioridad);
            comando.Parameters.AddWithValue("@estado", incidencia.Estado);
            comando.Parameters.AddWithValue("@fecha_creacion", DateTime.Now.ToString("yyyy-MM-dd"));
            comando.Parameters.AddWithValue("@id_reportero", incidencia.IdReportero);

            if (incidencia.IdTecnico == 0)
            {
                comando.Parameters.AddWithValue("@id_tecnico", DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@id_tecnico", incidencia.IdTecnico);
            }

            if (incidencia.IdCategoria == 0)
            {
                comando.Parameters.AddWithValue("@id_categoria", DBNull.Value);
            }
            else
            {
                comando.Parameters.AddWithValue("@id_categoria", incidencia.IdCategoria);
            }

            comando.ExecuteNonQuery();

            var administradores = UsuarioRepository.ObtenerAdministradores();

            foreach (var admin in administradores)
            {
                NotificacionRepository.CrearNotificacion(admin.Id, "Nueva incidencia reportada: " + incidencia.Titulo);
            }
        }

        public static List<Incidencia> ObtenerIncidencias()
        {
            List<Incidencia> listaIncidencias = new List<Incidencia>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT incidencias.id_incidencia,
                                           incidencias.titulo,
                                           incidencias.descripcion,
                                           incidencias.prioridad,
                                           incidencias.estado,
                                           incidencias.fecha_creacion,
                                           incidencias.fecha_cierre,
                                           incidencias.id_reportero,
                                           incidencias.id_tecnico,
                                           incidencias.id_categoria,
                                           categorias.nombre AS categoria,
                                           reportero.nombre || ' ' || reportero.apellido AS usuario_reportero,
                                           tecnico.nombre || ' ' || tecnico.apellido AS tecnico_asignado
                                    FROM incidencias
                                    INNER JOIN usuarios reportero ON incidencias.id_reportero = reportero.id_usuario
                                    LEFT JOIN usuarios tecnico ON incidencias.id_tecnico = tecnico.id_usuario
                                    LEFT JOIN categorias ON incidencias.id_categoria = categorias.id_categoria";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Incidencia incidencia = new Incidencia();

                incidencia.Id = reader.GetInt32(reader.GetOrdinal("id_incidencia"));
                incidencia.Titulo = reader["titulo"].ToString();
                incidencia.Descripcion = reader["descripcion"].ToString();
                incidencia.Prioridad = reader["prioridad"].ToString();
                incidencia.Estado = reader["estado"].ToString();
                incidencia.UsuarioReportero = reader["usuario_reportero"].ToString();
                incidencia.CategoriaIncidencia = reader["categoria"].ToString();
                incidencia.TecnicoAsignado = reader["tecnico_asignado"].ToString();

                incidencia.IdReportero = reader.GetInt32(reader.GetOrdinal("id_reportero"));

                if (reader["id_categoria"] == DBNull.Value)
                {
                    incidencia.IdCategoria = 0;
                }
                else
                {
                    incidencia.IdCategoria = reader.GetInt32(reader.GetOrdinal("id_categoria"));
                }

                if (reader["id_tecnico"] == DBNull.Value)
                {
                    incidencia.IdTecnico = 0;
                }
                else
                {
                    incidencia.IdTecnico = reader.GetInt32(reader.GetOrdinal("id_tecnico"));
                }

                if (reader["fecha_creacion"] != DBNull.Value)
                {
                    incidencia.AsignarFechaCreacion(DateTime.Parse(reader["fecha_creacion"].ToString()));
                }

                if (reader["fecha_cierre"] != DBNull.Value)
                {
                    incidencia.FechaCierre = DateTime.Parse(reader["fecha_cierre"].ToString());
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
            comando.CommandText = @"SELECT COUNT(*) 
                                    FROM incidencias";

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
                                    WHERE estado = 'Pendiente'";

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
                                    WHERE estado = 'En proceso'";

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

        public static int ObtenerIncidenciasPorEstado(string estado)
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
                                    WHERE estado = 'Pendiente'";

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

        public static List<Incidencia> ObtenerIncidenciasPorUsuario(int idUsuario)
        {
            List<Incidencia> listaIncidencias = new List<Incidencia>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT incidencias.id_incidencia,
                                           incidencias.titulo,
                                           incidencias.descripcion,
                                           incidencias.prioridad,
                                           incidencias.estado,
                                           incidencias.fecha_creacion,
                                           incidencias.fecha_cierre,
                                           incidencias.id_reportero,
                                           incidencias.id_tecnico,
                                           incidencias.id_categoria,
                                           categorias.nombre AS categoria,
                                           reportero.nombre || ' ' || reportero.apellido AS usuario_reportero,
                                           tecnico.nombre || ' ' || tecnico.apellido AS tecnico_asignado
                                    FROM incidencias
                                    INNER JOIN usuarios reportero ON incidencias.id_reportero = reportero.id_usuario
                                    LEFT JOIN usuarios tecnico ON incidencias.id_tecnico = tecnico.id_usuario
                                    LEFT JOIN categorias ON incidencias.id_categoria = categorias.id_categoria
                                    WHERE incidencias.id_reportero = @id_reportero";

            comando.Parameters.AddWithValue("@id_reportero", idUsuario);

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Incidencia incidencia = new Incidencia();

                incidencia.Id = reader.GetInt32(reader.GetOrdinal("id_incidencia"));
                incidencia.Titulo = reader["titulo"].ToString();
                incidencia.Descripcion = reader["descripcion"].ToString();
                incidencia.Prioridad = reader["prioridad"].ToString();
                incidencia.Estado = reader["estado"].ToString();
                incidencia.UsuarioReportero = reader["usuario_reportero"].ToString();
                incidencia.CategoriaIncidencia = reader["categoria"].ToString();
                incidencia.TecnicoAsignado = reader["tecnico_asignado"].ToString();

                incidencia.IdReportero = reader.GetInt32(reader.GetOrdinal("id_reportero"));

                if (reader["id_categoria"] == DBNull.Value)
                {
                    incidencia.IdCategoria = 0;
                }
                else
                {
                    incidencia.IdCategoria = reader.GetInt32(reader.GetOrdinal("id_categoria"));
                }

                if (reader["id_tecnico"] == DBNull.Value)
                {
                    incidencia.IdTecnico = 0;
                }
                else
                {
                    incidencia.IdTecnico = reader.GetInt32(reader.GetOrdinal("id_tecnico"));
                }

                if (reader["fecha_creacion"] != DBNull.Value)
                {
                    incidencia.AsignarFechaCreacion(DateTime.Parse(reader["fecha_creacion"].ToString()));
                }

                if (reader["fecha_cierre"] != DBNull.Value)
                {
                    incidencia.FechaCierre = DateTime.Parse(reader["fecha_cierre"].ToString());
                }

                listaIncidencias.Add(incidencia);
            }

            return listaIncidencias;
        }

        public static List<Incidencia> ObtenerIncidenciasPorTecnico(int idTecnico)
        {
            List<Incidencia> listaIncidencias = new List<Incidencia>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT incidencias.id_incidencia,
                                           incidencias.titulo,
                                           incidencias.descripcion,
                                           incidencias.prioridad,
                                           incidencias.estado,
                                           incidencias.fecha_creacion,
                                           incidencias.fecha_cierre,
                                           incidencias.id_reportero,
                                           incidencias.id_tecnico,
                                           incidencias.id_categoria,
                                           categorias.nombre AS categoria,
                                           reportero.nombre || ' ' || reportero.apellido AS usuario_reportero,
                                           tecnico.nombre || ' ' || tecnico.apellido AS tecnico_asignado
                                    FROM incidencias
                                    INNER JOIN usuarios reportero ON incidencias.id_reportero = reportero.id_usuario
                                    LEFT JOIN usuarios tecnico ON incidencias.id_tecnico = tecnico.id_usuario
                                    LEFT JOIN categorias ON incidencias.id_categoria = categorias.id_categoria
                                    WHERE incidencias.id_tecnico = @id_tecnico";

            comando.Parameters.AddWithValue("@id_tecnico", idTecnico);

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Incidencia incidencia = new Incidencia();

                incidencia.Id = reader.GetInt32(reader.GetOrdinal("id_incidencia"));
                incidencia.Titulo = reader["titulo"].ToString();
                incidencia.Descripcion = reader["descripcion"].ToString();
                incidencia.Prioridad = reader["prioridad"].ToString();
                incidencia.Estado = reader["estado"].ToString();
                incidencia.UsuarioReportero = reader["usuario_reportero"].ToString();
                incidencia.CategoriaIncidencia = reader["categoria"].ToString();
                incidencia.TecnicoAsignado = reader["tecnico_asignado"].ToString();

                incidencia.IdReportero = reader.GetInt32(reader.GetOrdinal("id_reportero"));

                if (reader["id_categoria"] == DBNull.Value)
                {
                    incidencia.IdCategoria = 0;
                }
                else
                {
                    incidencia.IdCategoria = reader.GetInt32(reader.GetOrdinal("id_categoria"));
                }

                if (reader["id_tecnico"] == DBNull.Value)
                {
                    incidencia.IdTecnico = 0;
                }
                else
                {
                    incidencia.IdTecnico = reader.GetInt32(reader.GetOrdinal("id_tecnico"));
                }

                if (reader["fecha_creacion"] != DBNull.Value)
                {
                    incidencia.AsignarFechaCreacion(DateTime.Parse(reader["fecha_creacion"].ToString()));
                }

                if (reader["fecha_cierre"] != DBNull.Value)
                {
                    incidencia.FechaCierre = DateTime.Parse(reader["fecha_cierre"].ToString());
                }

                listaIncidencias.Add(incidencia);
            }

            return listaIncidencias;
        }

        public static void ActualizarEstadoIncidencia(int idIncidencia, string estado)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"UPDATE incidencias
                                    SET estado = @estado
                                    WHERE id_incidencia = @id_incidencia";

            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@id_incidencia", idIncidencia);

            comando.ExecuteNonQuery();

            if (estado == "Resuelta")
            {
                int idUsuario = ObtenerIdUsuarioPorIncidencia(idIncidencia);

                if (idUsuario != 0)
                {
                    NotificacionRepository.CrearNotificacion(idUsuario, "Tu incidencia ha sido marcada como resuelta.");
                }
            }
        }

        public static int ObtenerIncidenciasAsignadas()
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) 
                                    FROM incidencias
                                    WHERE estado = 'Asignada'";

            long resultado = (long)comando.ExecuteScalar();

            return (int)resultado;
        }

        public static int ObtenerIncidenciasResueltas()
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*) 
                                    FROM incidencias
                                    WHERE estado = 'Resuelta'";

            long resultado = (long)comando.ExecuteScalar();

            return (int)resultado;
        }

        public static int ObtenerIdUsuarioPorIncidencia(int idIncidencia)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT id_reportero
                                    FROM incidencias
                                    WHERE id_incidencia = @id_incidencia";

            comando.Parameters.AddWithValue("@id_incidencia", idIncidencia);

            object resultado = comando.ExecuteScalar();

            if (resultado == null || resultado == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(resultado);
        }

        public static void ActualizarIncidenciaUsuario(Incidencia incidencia)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"UPDATE incidencias
                            SET titulo = @titulo,
                                descripcion = @descripcion,
                                prioridad = @prioridad,
                                id_categoria = @id_categoria
                            WHERE id_incidencia = @id_incidencia";

            comando.Parameters.AddWithValue("@titulo", incidencia.Titulo);
            comando.Parameters.AddWithValue("@descripcion", incidencia.Descripcion);
            comando.Parameters.AddWithValue("@prioridad", incidencia.Prioridad);
            comando.Parameters.AddWithValue("@id_categoria", incidencia.IdCategoria);
            comando.Parameters.AddWithValue("@id_incidencia", incidencia.Id);

            comando.ExecuteNonQuery();
        }
    }
}
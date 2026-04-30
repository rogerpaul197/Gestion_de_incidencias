/// <summary>
/// Esta clase contiene las operaciones relacionadas con las incidencias en la base de datos.
/// </summary>

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
                                    (titulo, descripcion, categoria, id_categoria, prioridad, estado, id_usuario, usuario_reportero, fecha_creacion)
                                    VALUES 
                                    (@titulo, @descripcion, @categoria, @id_categoria, @prioridad, @estado, @id_usuario, @usuario_reportero, @fecha_creacion)";

            comando.Parameters.AddWithValue("@titulo", incidencia.Titulo);
            comando.Parameters.AddWithValue("@descripcion", incidencia.Descripcion);
            comando.Parameters.AddWithValue("@categoria", incidencia.Categoria);
            comando.Parameters.AddWithValue("@prioridad", incidencia.Prioridad);
            comando.Parameters.AddWithValue("@fecha_creacion", DateTime.Now.ToString("yyyy-MM-dd"));
            comando.Parameters.AddWithValue("@id_categoria", incidencia.IdCategoria);
            comando.Parameters.AddWithValue("@estado", incidencia.Estado);
            comando.Parameters.AddWithValue("@id_usuario", incidencia.IdUsuario);
            comando.Parameters.AddWithValue("@usuario_reportero", incidencia.UsuarioReportero);

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
            comando.CommandText = @"SELECT id, titulo, descripcion, categoria, id_categoria, prioridad, estado, id_usuario, usuario_reportero, id_tecnico, fecha_creacion
                                    FROM incidencias";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Incidencia incidencia = new Incidencia();

                incidencia.Id = reader.GetInt32(reader.GetOrdinal("id"));
                incidencia.Titulo = reader["titulo"].ToString();
                incidencia.Descripcion = reader["descripcion"].ToString();
                incidencia.Categoria = reader["categoria"].ToString();
                incidencia.Prioridad = reader["prioridad"].ToString();
                incidencia.Estado = reader["estado"].ToString();
                incidencia.UsuarioReportero = reader["usuario_reportero"].ToString();

                if (reader["id_categoria"] == DBNull.Value)
                {
                    incidencia.IdCategoria = 0;
                }
                else
                {
                    incidencia.IdCategoria = reader.GetInt32(reader.GetOrdinal("id_categoria"));
                }

                if (reader["id_usuario"] == DBNull.Value)
                {
                    incidencia.IdUsuario = 0;
                }
                else
                {
                    incidencia.IdUsuario = reader.GetInt32(reader.GetOrdinal("id_usuario"));
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
            comando.CommandText = @"SELECT id, titulo, descripcion, categoria, id_categoria, prioridad, estado, id_usuario, usuario_reportero, id_tecnico, fecha_creacion
                                    FROM incidencias
                                    WHERE id_usuario = @id_usuario";

            comando.Parameters.AddWithValue("@id_usuario", idUsuario);

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Incidencia incidencia = new Incidencia();

                incidencia.Id = reader.GetInt32(reader.GetOrdinal("id"));
                incidencia.Titulo = reader["titulo"].ToString();
                incidencia.Descripcion = reader["descripcion"].ToString();
                incidencia.Categoria = reader["categoria"].ToString();
                incidencia.Prioridad = reader["prioridad"].ToString();
                incidencia.Estado = reader["estado"].ToString();
                incidencia.UsuarioReportero = reader["usuario_reportero"].ToString();

                if (reader["id_categoria"] == DBNull.Value)
                {
                    incidencia.IdCategoria = 0;
                }
                else
                {
                    incidencia.IdCategoria = reader.GetInt32(reader.GetOrdinal("id_categoria"));
                }

                if (reader["id_usuario"] == DBNull.Value)
                {
                    incidencia.IdUsuario = 0;
                }
                else
                {
                    incidencia.IdUsuario = reader.GetInt32(reader.GetOrdinal("id_usuario"));
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
                    incidencia.AsignarFechaRegistro(DateTime.Parse(reader["fecha_creacion"].ToString()));
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
            comando.CommandText = @"SELECT id, titulo, descripcion, categoria, id_categoria, prioridad, estado, id_usuario, usuario_reportero, id_tecnico, fecha_creacion
                                    FROM incidencias
                                    WHERE id_tecnico = @id_tecnico";

            comando.Parameters.AddWithValue("@id_tecnico", idTecnico);

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Incidencia incidencia = new Incidencia();

                incidencia.Id = reader.GetInt32(reader.GetOrdinal("id"));
                incidencia.Titulo = reader["titulo"].ToString();
                incidencia.Descripcion = reader["descripcion"].ToString();
                incidencia.Categoria = reader["categoria"].ToString();
                incidencia.Prioridad = reader["prioridad"].ToString();
                incidencia.Estado = reader["estado"].ToString();
                incidencia.UsuarioReportero = reader["usuario_reportero"].ToString();

                if (reader["id_categoria"] == DBNull.Value)
                {
                    incidencia.IdCategoria = 0;
                }
                else
                {
                    incidencia.IdCategoria = reader.GetInt32(reader.GetOrdinal("id_categoria"));
                }

                if (reader["id_usuario"] == DBNull.Value)
                {
                    incidencia.IdUsuario = 0;
                }
                else
                {
                    incidencia.IdUsuario = reader.GetInt32(reader.GetOrdinal("id_usuario"));
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
                    incidencia.AsignarFechaRegistro(DateTime.Parse(reader["fecha_creacion"].ToString()));
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
                                    WHERE id = @id";

            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@id", idIncidencia);

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
            comando.CommandText = @"SELECT id_usuario
                                    FROM incidencias
                                    WHERE id = @id";

            comando.Parameters.AddWithValue("@id", idIncidencia);

            object resultado = comando.ExecuteScalar();

            if (resultado == null || resultado == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(resultado);
        }
    }
}
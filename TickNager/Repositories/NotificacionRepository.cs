/// <summary>
/// Esta clase contiene las operaciones relacionadas con las notificaciones en la base de datos.
/// </summary>

using TickNager.Helper;
using TickNager.Models;

namespace TickNager.Repositories
{
    public class NotificacionRepository
    {
        /// <summary>
        /// Esta función crea una nueva notificación para un usuario.
        /// </summary>
        /// <param name="idUsuarioDestino">Id del usuario que recibirá la notificación.</param>
        /// <param name="mensaje">Mensaje que tendrá la notificación.</param>
        public static void CrearNotificacion(int idUsuario, string mensaje)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"INSERT INTO notificaciones
                                    (mensaje, leido, fecha, id_usuario)
                                    VALUES
                                    (@mensaje,@leido, @fecha, @id_usuario)";

            comando.Parameters.AddWithValue("@mensaje", mensaje);
            comando.Parameters.AddWithValue("@leido", 0);
            comando.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            comando.Parameters.AddWithValue("@id_usuario", idUsuario);

            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Esta función obtiene las notificaciones de un usuario.
        /// </summary>
        /// <param name="idUsuario">Id del usuario del que se quieren obtener las notificaciones.</param>
        /// <returns>Devuelve una lista con las notificaciones del usuario.</returns>
        public static List<Notificacion> ObtenerNotificacionesUsuario(int idUsuario)
        {
            List<Notificacion> listaNotificaciones = new List<Notificacion>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT id_notificacion, mensaje, leido, fecha, id_usuario
                                    FROM notificaciones
                                    WHERE id_usuario = @id_usuario
                                    ORDER BY fecha DESC";

            comando.Parameters.AddWithValue("@id_usuario", idUsuario);

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Notificacion notificacion = new Notificacion();

                notificacion.Id = reader.GetInt32(reader.GetOrdinal("id_notificacion"));
                notificacion.IdUsuario = reader.GetInt32(reader.GetOrdinal("id_usuario"));
                notificacion.Mensaje = reader["mensaje"].ToString();
                notificacion.Leido = reader.GetInt32(reader.GetOrdinal("leido")) == 1;
                notificacion.Fecha = reader["fecha"].ToString();

                listaNotificaciones.Add(notificacion);
            }

            return listaNotificaciones;
        }

        /// <summary>
        /// Esta función cuenta las notificaciones no leídas de un usuario.
        /// </summary>
        /// <param name="idUsuario">Id del usuario del que se contarán las notificaciones no leídas.</param>
        /// <returns>Devuelve la cantidad de notificaciones no leídas.</returns>
        public static int ContarNoLeidas(int idUsuario)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*)
                                    FROM notificaciones
                                    WHERE id_usuario = @id_usuario
                                    AND leido = 0";

            comando.Parameters.AddWithValue("@id_usuario", idUsuario);

            long resultado = (long)comando.ExecuteScalar();

            return (int)resultado;
        }

        /// <summary>
        /// Esta función marca todas las notificaciones de un usuario como leídas.
        /// </summary>
        /// <param name="idUsuario">Id del usuario al que se le marcarán las notificaciones como leídas.</param>
        public static void MarcarTodasComoLeidas(int idUsuario)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"UPDATE notificaciones
                                    SET leido = 1
                                    WHERE id_usuario = @id_usuario";

            comando.Parameters.AddWithValue("@id_usuario", idUsuario);

            comando.ExecuteNonQuery();
        }
    }
}
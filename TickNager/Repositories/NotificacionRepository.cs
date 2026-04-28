using System.Collections.Generic;
using TickNager.Helper;
using TickNager.Models;

namespace TickNager.Repositories
{
    public class NotificacionRepository
    {
        public static void CrearNotificacion(int idUsuarioDestino, string mensaje)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"INSERT INTO notificaciones
                                    (id_usuario_destino, mensaje, leida)
                                    VALUES
                                    (@id_usuario_destino, @mensaje, 0)";

            comando.Parameters.AddWithValue("@id_usuario_destino", idUsuarioDestino);
            comando.Parameters.AddWithValue("@mensaje", mensaje);

            comando.ExecuteNonQuery();
        }

        public static List<Notificacion> ObtenerNotificacionesUsuario(int idUsuario)
        {
            List<Notificacion> lista = new List<Notificacion>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT id, id_usuario_destino, mensaje, leida, fecha
                                    FROM notificaciones
                                    WHERE id_usuario_destino = @id_usuario
                                    ORDER BY fecha DESC";

            comando.Parameters.AddWithValue("@id_usuario", idUsuario);

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Notificacion notificacion = new Notificacion();

                notificacion.Id = reader.GetInt32(reader.GetOrdinal("id"));
                notificacion.IdUsuarioDestino = reader.GetInt32(reader.GetOrdinal("id_usuario_destino"));
                notificacion.Mensaje = reader["mensaje"].ToString();
                notificacion.Leida = reader.GetInt32(reader.GetOrdinal("leida")) == 1;
                notificacion.Fecha = reader["fecha"].ToString();

                lista.Add(notificacion);
            }

            return lista;
        }

        public static int ContarNoLeidas(int idUsuario)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT COUNT(*)
                                    FROM notificaciones
                                    WHERE id_usuario_destino = @id_usuario
                                    AND leida = 0";

            comando.Parameters.AddWithValue("@id_usuario", idUsuario);

            long resultado = (long)comando.ExecuteScalar();

            return (int)resultado;
        }

        public static void MarcarTodasComoLeidas(int idUsuario)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"UPDATE notificaciones
                                    SET leida = 1
                                    WHERE id_usuario_destino = @id_usuario";

            comando.Parameters.AddWithValue("@id_usuario", idUsuario);

            comando.ExecuteNonQuery();
        }
    }
}
using System.Collections.Generic;
using TickNager.Helper;
using TickNager.Models;

namespace TickNager.Repositories
{
    public class ComentarioRepository
    {
        public static void CrearComentario(Comentario comentario)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();

            comando.CommandText = @"INSERT INTO comentarios
                                    (id_incidencia, usuario, mensaje, fecha)
                                    VALUES
                                    (@id_incidencia, @usuario, @mensaje, @fecha)";

            comando.Parameters.AddWithValue("@id_incidencia", comentario.IdIncidencia);
            comando.Parameters.AddWithValue("@usuario", comentario.Usuario);
            comando.Parameters.AddWithValue("@mensaje", comentario.Mensaje);
            comando.Parameters.AddWithValue("@fecha", comentario.Fecha);

            comando.ExecuteNonQuery();
        }

        public static List<Comentario> ObtenerComentarios(int idIncidencia)
        {
            List<Comentario> listaComentarios = new List<Comentario>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();

            comando.CommandText = @"SELECT id_comentario,
                                           id_incidencia,
                                           usuario,
                                           mensaje,
                                           fecha
                                    FROM comentarios
                                    WHERE id_incidencia = @id_incidencia
                                    ORDER BY id_comentario ASC";

            comando.Parameters.AddWithValue("@id_incidencia", idIncidencia);

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Comentario comentario = new Comentario();

                comentario.Id = reader.GetInt32(0);
                comentario.IdIncidencia = reader.GetInt32(1);
                comentario.Usuario = reader.GetString(2);
                comentario.Mensaje = reader.GetString(3);
                comentario.Fecha = reader.GetString(4);

                listaComentarios.Add(comentario);
            }

            return listaComentarios;
        }
    }
}
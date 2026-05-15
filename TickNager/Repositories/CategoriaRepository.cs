/// <summary>
/// Esta clase contiene las operaciones relacionadas con las categorías en la base de datos.
/// </summary>

using TickNager.Helper;
using TickNager.Models;

namespace TickNager.Repositories
{
    public class CategoriaRepository
    {
        /// <summary>
        /// Esta función registra una nueva categoría en la base de datos.
        /// </summary>
        /// <param name="categoria">Categoría que se va a registrar.</param>
        public static void RegistrarCategoria(Categoria categoria)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"INSERT INTO categorias
                                    (nombre, descripcion, activo, cantidad_incidencias)
                                    VALUES
                                    (@nombre, @descripcion, @activo, @cantidad_incidencias)";

            comando.Parameters.AddWithValue("@nombre", categoria.Nombre);
            comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
            comando.Parameters.AddWithValue("@activo", categoria.Activo ? 1 : 0);
            comando.Parameters.AddWithValue("@cantidad_incidencias", categoria.CantidadIncidencias);

            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Esta función obtiene todas las categorías registradas en la base de datos.
        /// </summary>
        /// <returns>Devuelve una lista con todas las categorías.</returns>
        public static List<Categoria> ObtenerCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT categorias.id_categoria, categorias.nombre, categorias.descripcion, categorias.activo,
                                    COUNT(incidencias.id_incidencia) AS cantidad_incidencias
                                    FROM categorias
                                    LEFT JOIN incidencias ON incidencias.id_categoria = categorias.id_categoria
                                    GROUP BY categorias.id_categoria, categorias.nombre, categorias.descripcion, categorias.activo";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Categoria categoria = new Categoria();

                categoria.Id = reader.GetInt32(reader.GetOrdinal("id_categoria"));
                categoria.Nombre = reader["nombre"].ToString();
                categoria.Descripcion = reader["descripcion"].ToString();
                categoria.Activo = reader.GetInt32(reader.GetOrdinal("activo")) == 1;
                categoria.CantidadIncidencias = reader.GetInt32(reader.GetOrdinal("cantidad_incidencias"));

                listaCategorias.Add(categoria);
            }

            return listaCategorias;
        }

        public static int ObtenerIdCategoria(string nombreCategoria)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT id_categoria
                            FROM categorias
                            WHERE nombre = @nombre";

            comando.Parameters.AddWithValue("@nombre", nombreCategoria);

            object resultado = comando.ExecuteScalar();

            if (resultado == null || resultado == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(resultado);
        }
    }
}
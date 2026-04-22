using System.Collections.Generic;
using System.Windows;
using TickNager.Helper;
using TickNager.Models;

namespace TickNager.Repositories
{
    public class CategoriaRepository
    {
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

        public static List<Categoria> ObtenerCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT nombre, descripcion, activo, cantidad_incidencias
                            FROM categorias";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Categoria categoria = new Categoria
                {
                    Nombre = reader["nombre"].ToString(),
                    Descripcion = reader["descripcion"].ToString(),
                    Activo = reader.GetInt32(reader.GetOrdinal("activo")) == 1,
                    CantidadIncidencias = reader.GetInt32(reader.GetOrdinal("cantidad_incidencias"))
                };

                listaCategorias.Add(categoria);
            }

            return listaCategorias;
        }
    }
}
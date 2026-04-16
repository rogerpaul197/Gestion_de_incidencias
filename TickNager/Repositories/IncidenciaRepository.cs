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
                                    (titulo, descripcion, categoria, prioridad)
                                    VALUES 
                                    (@titulo, @descripcion, @categoria, @prioridad)";

            comando.Parameters.AddWithValue("@titulo", incidencia.Titulo);
            comando.Parameters.AddWithValue("@descripcion", incidencia.Descripcion);
            comando.Parameters.AddWithValue("@categoria", incidencia.Categoria);
            comando.Parameters.AddWithValue("@prioridad", incidencia.Prioridad);
            comando.ExecuteNonQuery();
        }
    }
}

/// <summary>
/// Esta clase contiene las operaciones relacionadas con los técnicos en la base de datos.
/// </summary>

using System.Collections.Generic;
using TickNager.Helper;
using TickNager.Models;

namespace TickNager.Repositories
{
    public class TecnicoRepository
    {
        /// <summary>
        /// Esta función obtiene todos los usuarios que tienen rol de técnico.
        /// </summary>
        /// <returns>Devuelve una lista con todos los técnicos.</returns>
        public static List<Usuario> ObtenerTecnicos()
        {
            List<Usuario> listaTecnicos = new List<Usuario>();

            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"SELECT id, nombre, apellido, rol, genero, departamento, numero, correo, contrasena
                                    FROM usuarios
                                    WHERE rol = 'Técnico'";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Usuario tecnico = new Usuario();

                tecnico.Id = reader.GetInt32(reader.GetOrdinal("id"));
                tecnico.NombreUsuario = reader["nombre"].ToString();
                tecnico.ApellidoUsuario = reader["apellido"].ToString();
                tecnico.RolUsuario = reader["rol"].ToString();
                tecnico.GeneroUsuario = reader["genero"].ToString();
                tecnico.Departamento = reader["departamento"].ToString();
                tecnico.NumeroUsuario = reader["numero"].ToString();
                tecnico.CorreoUsuario = reader["correo"].ToString();
                tecnico.ContrasenaUsuario = reader["contrasena"].ToString();

                listaTecnicos.Add(tecnico);
            }

            return listaTecnicos;
        }
    }
}
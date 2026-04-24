using System.Collections.Generic;
using TickNager.Helper;
using TickNager.Models;

namespace TickNager.Repositories
{
    public class TecnicoRepository
    {
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
                Usuario tecnico = new Usuario
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    NombreUsuario = reader["nombre"].ToString(),
                    ApellidoUsuario = reader["apellido"].ToString(),
                    RolUsuario = reader["rol"].ToString(),
                    GeneroUsuario = reader["genero"].ToString(),
                    Departamento = reader["departamento"].ToString(),
                    NumeroUsuario = reader["numero"].ToString(),
                    CorreoUsuario = reader["correo"].ToString(),
                    ContrasenaUsuario = reader["contrasena"].ToString()
                };

                listaTecnicos.Add(tecnico);
            }

            return listaTecnicos;
        }
    }
}
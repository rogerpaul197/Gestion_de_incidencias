using System;
using System.Collections.Generic;
using System.Text;
using TickNager.Models;
using TickNager.Helper;   

namespace TickNager.Repositories
{
    public class RegistroRepository
    {
        public void RegistarUsuario(Usuario usuario)
        {
            using var conexion = DatabaseHelper.getConexionBaseDatos();
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"INSERT INTO usuarios 
                                    (nombre, apellido, rol, numero, genero, correo, contrasena)
                                    VALUES 
                                    (@nombre, @apellido, @rol, @numero, @genero, @correo, @contrasena)";

            comando.Parameters.AddWithValue("@nombre", usuario.NombreUsuario);
            comando.Parameters.AddWithValue("@apellido", usuario.ApellidoUsuario);
            comando.Parameters.AddWithValue("@rol", usuario.RolUsuario);
            comando.Parameters.AddWithValue("@numero", usuario.NumeroUsuario);
            comando.Parameters.AddWithValue("@genero", usuario.GeneroUsuario);
            comando.Parameters.AddWithValue("@correo", usuario.CorreoUsuario);
            comando.Parameters.AddWithValue("@contrasena", usuario.ContrasenaUsuario);
            comando.ExecuteNonQuery();
        }
    }
}

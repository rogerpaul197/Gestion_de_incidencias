using TickNager.Models;

/// <summary>
/// Aquí van a ir las funciones que se van a ir usando de forma repetitiva.
/// </summary>
namespace TickNager.Helper
{
    public class FuncionesHelper
    {
        /// <summary>
        /// Esta función se encarga de registrar un nuevo usuario en la base de datos.
        /// Será static para llamarlo desde cualquier parte del proyecto sin necesidad de crear una instancia de la clase FuncionesHelper.
        /// </summary>
        /// <param name="usuario"></param>
        public static void RegistarUsuario(Usuario usuario)
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

        //Estas 2 funciones faltan por hacer
        /*
        /// <summary>
        /// Esta función se encarga de actualizar la imagen y el texto del rol dependiendo del género seleccionado por el usuario a la hora de registrar.
        /// Si el usuario elije primero el rol y luego el género.
        /// </summary>
        /// <param name="rol"></param>
        public static void actualizarImagenTextoPorRol(string rol, string genero, string textoRol, string imagenPerfil)
        {
            switch (rol)
            {
                case "Administrador":
                    if (genero == "Hombre")
                    {
                        textoRol = "Administrador";
                        imagenPerfil = "/Imagenes/Iconos/perfil_administrador.png";
                    } else if (genero == "Mujer")
                    {
                        textoRol = "Administradora";
                        imagenPerfil = "/Imagenes/Iconos/perfil_administradora.png";
                    }
                    break;

                case "Administradora":
                    if (genero == "Hombre")
                    {
                        textoRol = "Administrador";
                        imagenPerfil = "/Imagenes/Iconos/perfil_administrador.png";
                    } else if (genero == "Mujer")
                    {
                        textoRol = "Administradora";
                        imagenPerfil = "/Imagenes/Iconos/perfil_administradora.png";
                    }
                    break;

                case "Técnico":
                    textoRol = "Técnico";
                    imagenPerfil = "/Imagenes/Iconos/perfil_tecnico.png";
                    break;

                case "Técnica":
                    textoRol = "Técnica";
                    imagenPerfil = "/Imagenes/Iconos/perfil_tecnica.png";
                    break;

                case "Usuario":
                    textoRol = "Usuario";
                    imagenPerfil = "/Imagenes/Iconos/perfil_usuario.png";
                    break;

                case "Usuaria":
                    textoRol = "Usuaria";
                    imagenPerfil = "/Imagenes/Iconos/perfil_usuaria.png";
                    break;

                default:
                    textoRol = "Selecciona un rol";
                    imagenPerfil = "/Imagenes/Iconos/perfil_usuario.png";
                    break;
            }
        }

        /// <summary>
        /// Esta función se encarga de actualizar la imagen y el texto del rol dependiendo del género seleccionado por el usuario a la hora de registrar.
        /// Si el usuario primero elige el género y luego el rol.
        /// </summary>
        /// <param name="genero"></param>
        /// <param name="rol"></param>
        /// <param name="textoRol"></param>
        /// <param name="imagenPerfil"></param>
        public static void actualizaImagenTextoPorGenero(string genero, string rol, string textoRol, string imagenPerfil)
        {
            switch (genero)
            {
                case "Hombre":
                    if (rol == "Administrador")
                    {
                        textoRol = "Administrador";
                        imagenPerfil = "/Imagenes/Iconos/perfil_administrador.png";

                    }
                    else if (rol == "Técnico")
                    {
                        textoRol = "Técnico";
                        imagenPerfil = "/Imagenes/Iconos/perfil_tecnico.png";
                    }
                    else if (rol == "Usuario")
                    {
                        textoRol = "Usuario";
                        imagenPerfil = "/Imagenes/Iconos/perfil_usuario.png";
                    }
                    break;

                case "Mujer":
                    if (rol == "Administradora")
                    {
                        textoRol = "Administradora";
                        imagenPerfil = "/Imagenes/Iconos/perfil_administradora.png";
                    }
                    else if (rol == "Técnica")
                    {
                        textoRol = "Técnica";
                        imagenPerfil = "/Imagenes/Iconos/perfil_tecnica.png";
                    }
                    else if (rol == "Usuaria")
                    {
                        textoRol = "Usuaria";
                        imagenPerfil = "/Imagenes/Iconos/perfil_usuaria.png";
                    }
                    break;

                default:
                    textoRol = "Selecciona un rol";
                    imagenPerfil = "/Imagenes/Iconos/perfil_usuario.png";
                    break;
            }
        }*/
    }
}

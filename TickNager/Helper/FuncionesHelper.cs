/// <summary>
/// Aquí van a ir las funciones que se van a ir usando de forma repetitiva.
/// </summary>

using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.Helper
{
    public class FuncionesHelper
    {
        /// <summary>
        /// Esta función se encarga de obtener la ruta de la imagen del perfil dependiendo del rol y género seleccionados.
        /// </summary>
        /// <param name="rol">El rol del usuario (Administrador, Técnico, Usuario)</param>
        /// <param name="genero">El género del usuario (Hombre, Mujer)</param>
        /// <returns>La ruta de la imagen correspondiente al rol y género</returns>
        public static string ObtenerImagenPerfil(string rol, string genero)
        {
            switch (rol)
            {
                case "Administrador":
                    if (genero == "Mujer")
                    {
                        return "/Imagenes/Iconos/perfil_administradora.png";
                    }
                    else
                    {
                        return "/Imagenes/Iconos/perfil_administrador.png";
                    }

                case "Técnico":
                    if (genero == "Mujer")
                    {
                        return "/Imagenes/Iconos/perfil_tecnica.png";
                    }
                    else
                    {
                        return "/Imagenes/Iconos/perfil_tecnico.png";
                    }

                case "Usuario":
                    if (genero == "Mujer")
                    {
                        return "/Imagenes/Iconos/perfil_usuaria.png";
                    }
                    else
                    {
                        return "/Imagenes/Iconos/perfil_usuario.png";
                    }

                default:
                    return "/Imagenes/Iconos/perfil_usuario.png";
            }
        }
    }
}
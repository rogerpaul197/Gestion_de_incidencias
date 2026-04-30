using System;
using System.Collections.Generic;
using System.Text;
using TickNager.Models;

namespace TickNager.Helper
{
    public  class SesionUsuarioHelper
    {
        public static Usuario UsuarioActual { get; set; }

        public static void CerrarSesion()
        {
            UsuarioActual = null;
        }
    }
}

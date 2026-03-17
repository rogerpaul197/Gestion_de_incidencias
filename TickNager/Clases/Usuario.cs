using System;
using System.Collections.Generic;
using System.Text;

namespace TickNager.Clases
{
    public class Usuario
    {
        public string nombreUsuario;
        public string apellidoUsuario;
        public string? numeroUsuario;
        public string correoUsuario;
        public string contrasenaUsuario;
        public Usuario()
        {

        }

        public Usuario(string nombreUsuario, string apellidoUsuario, string? numeroUsuario, string correoUsuario, string contrasenaUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.apellidoUsuario = apellidoUsuario;
            this.numeroUsuario = numeroUsuario;
            this.correoUsuario = correoUsuario;
            this.contrasenaUsuario = contrasenaUsuario;
        }

        
    }
}

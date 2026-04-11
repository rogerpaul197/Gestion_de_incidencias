using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TickNager.Models
{
    public class Empresa
    {
        private string _nombre;
        private string _nif_cif;
        private string _ciudad;
        private string _codigoPostal;
        private string _direccion;
        private string _correo;
        public string Nombre
        {
            get { return _nombre; }
            set 
            { 
                _nombre = value; 
            }
        }
    }
}

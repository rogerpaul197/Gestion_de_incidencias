using System;
using System.Collections.Generic;
using System.Text;

namespace TickNager.ViewModels
{
    public class InformacionWindow2ViewModel
    {
        private string _informacion = "Si eres un usuario o técnico, debes solicitar que se te registre al programa al administrador para que se te dé de alta, una vez dado de " + "alta, debes iniciar sesión con las credenciales que el administrador te haiga asignado.";

        public string Informacion
        {
            get { return _informacion; }
            set
            {
                _informacion = value;
            }
        }
    }
}

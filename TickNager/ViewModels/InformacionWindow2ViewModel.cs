using System;
using System.Collections.Generic;
using System.Text;

namespace TickNager.ViewModels
{
    public class InformacionWindow2ViewModel
    {
        private string _informacion = "Si eres un usuario o técnico, debes solicitar \nque se te registre al programa al administrador \npara que se te dé de alta, una vez dado de alta, " +
            "\ndebes iniciar sesión con las credenciales \nque el administrador te haiga asignado.";

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

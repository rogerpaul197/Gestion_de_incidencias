using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using TickNager.UserControls;

namespace TickNager.ViewModels
{
    public class VistaIncidenciasViewModel
    {
        public static bool presionoBoton(bool estadoBoton)
        {
            if (estadoBoton == true)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using TickNager.Commands;
using TickNager.UserControls;
using TickNager.Views.Windows;

namespace TickNager.ViewModels
{
    public class BotonesUsuarioViewModel
    {
        UserControl vistaActual;

        public BotonesUsuarioViewModel()
        {
            //anadirUsuario = new RelayCommand(anadirUsuarioNuevo);
        }

        /// <summary>
        /// Muestra el formulario al presionar el botón de añadir usuario nuevo.
        /// </summary>
        public void anadirUsuarioNuevo()
        {
            vistaActual = new FormularioCrearUsuario();
        }

        public void eliminarUsuario()
        {
            
        }
    }
}

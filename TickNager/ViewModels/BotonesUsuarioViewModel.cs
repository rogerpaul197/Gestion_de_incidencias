using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TickNager.Commands;
using TickNager.Views.Windows;

namespace TickNager.ViewModels
{
    public class BotonesUsuarioViewModel
    {
        public ICommand anadirUsuario { get; set; }
        public ICommand eliminarUsuario { get; set; }

        public BotonesUsuarioViewModel()
        {
            anadirUsuario = new RelayCommand(anadirUsuarioNuevo);
        }

        public void anadirUsuarioNuevo(object obj)
        {
            CrearUsuarioWindow ventana = new CrearUsuarioWindow();
            ventana.Show();
        }
    }
}

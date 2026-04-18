using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using TickNager.Models;
using TickNager.Repositories;
using TickNager.UserControls;

namespace TickNager.ViewModels
{
    public class VistaGestionUsuariosViewModel
    {
        public ObservableCollection<Usuario> Usuarios { get; set; }

        public VistaGestionUsuariosViewModel()
        {
            Usuarios = new ObservableCollection<Usuario>();
            CargarUsuarios();
        }

        public void CargarUsuarios()
        {
            Usuarios.Clear();

            var lista = UsuarioRepository.ObtenerUsuarios();

            foreach (var usuario in lista)
            {
                Usuarios.Add(usuario);
            }
        }
    }
}

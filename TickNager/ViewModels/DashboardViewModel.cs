using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TickNager.Commands;
using TickNager.UserControls;

namespace TickNager.ViewModels
{
    public class DashboardViewModel
    {
        public ICommand incidencias { get; set; }
        public ICommand gestionUsuarios { get; set; }
        public ICommand equipos { get; set; }
        public ICommand categorias { get; set; }
        public ICommand ajustes { get; set; }

        DashboardViewModel()
        {
            gestionUsuarios = new RelayCommand(MostrarGestionUsuarios, CanMostrarGestionUsuarios);
        }

        private bool CanMostrarGestionUsuarios(object obj)
        {
            return true;
        }

        private void MostrarGestionUsuarios(object obj)
        {
            UsuarioCreado usuarioCreado = new UsuarioCreado();
        }
    }
}

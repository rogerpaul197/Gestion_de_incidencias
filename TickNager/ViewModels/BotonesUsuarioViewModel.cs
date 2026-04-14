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
        private DashboardViewModel _dashboardViewModel;

        public BotonesUsuarioViewModel()
        {
            //anadirUsuario = new RelayCommand(anadirUsuarioNuevo);
        }

        public BotonesUsuarioViewModel(DashboardViewModel dashboardViewModel)
        {
            _dashboardViewModel = dashboardViewModel;
        }

        /// <summary>
        /// Muestra el formulario al presionar el botón de añadir usuario nuevo.
        /// </summary>
        public void anadirUsuarioNuevo()
        {
            if (_dashboardViewModel != null)
            {
                _dashboardViewModel.mostrarFormularioCrearUsuario();
            }
        }

        public void eliminarUsuario()
        {

        }
    }
}

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TickNager.Commands;
using TickNager.Views.Windows;

namespace TickNager.ViewModels
{
    public class InformacionWindowViewModel
    {
        private string _informacion = "Bienvenido a TickNager, una aplicación de \ngestión de incidencias, " +
            "si tu función es gestionar \nlas incidencias cómo asignarlos y ver sus estados, \ndebes registrarte y colocar los datos solicitados.";

        public string Informacion
        {
            get { return _informacion; }
            set
            {
                _informacion = value;
            }
        }

        public ICommand MostrarInfo { get; }

        public InformacionWindowViewModel()
        {
            MostrarInfo = new RelayCommand(mostrarSiguienteInformacion);
        }

        public void mostrarSiguienteInformacion(object parameter)
        {
            
            InformacionWindow ventana1 = new InformacionWindow();

            InformacionWindow2 ventana2 = new InformacionWindow2();
            ventana2.Show();
        }
    }
}

using System.Windows;
using TickNager.Models;
using TickNager.Repositories;
using TickNager.UserControls;

namespace TickNager.ViewModels
{
    public class FormularioCrearIncidenciaViewModel
    {
        private string _titulo;
        private string _descripcion;
        private string _categoria;
        private string _prioridad;
        private DashboardViewModel _dashboardViewModel;

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public string Prioridad
        {
            get { return _prioridad; }
            set { _prioridad = value; }
        }

        public FormularioCrearIncidenciaViewModel()
        {
        }

        public FormularioCrearIncidenciaViewModel(DashboardViewModel dashboardViewModel)
        {
            _dashboardViewModel = dashboardViewModel;
        }

        public void crearIncidencia()
        {
            if (Titulo == null || Descripcion == null || Prioridad == null)
            {
                MessageBox.Show("Por favor, complete todos los campos para crear la incidencia.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } else
            {
                Incidencia incidencia = new Incidencia(Titulo, Descripcion, Categoria, Prioridad);
                IncidenciaRepository.RegistrarIncidencia(incidencia);
                MessageBox.Show("Incidencia registrada.");
            }
        }

        public void volverAVistaIncidencias()
        {
            
        }
    }
}
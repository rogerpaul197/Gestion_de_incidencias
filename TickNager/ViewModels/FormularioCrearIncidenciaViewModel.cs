using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TickNager.Models;
using TickNager.Repositories;
using TickNager.UserControls;

namespace TickNager.ViewModels
{
    public class FormularioCrearIncidenciaViewModel : INotifyPropertyChanged
    {
        private string _titulo;
        private string _descripcion;
        private string? _categoria;
        private string _prioridad;
        private DashboardViewModel _obj;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }

        public string Titulo
        {
            get { return _titulo; }
            set 
            { 
                _titulo = value;
                OnPropertyChanged();
            }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set 
            { 
                _descripcion = value;
                OnPropertyChanged();
            }
        }

        public string? Categoria
        {
            get { return _categoria; }
            set 
            { 
                _categoria = value;
                OnPropertyChanged();
            }
        }

        public string Prioridad
        {
            get { return _prioridad; }
            set 
            { 
                _prioridad = value;
                OnPropertyChanged();
            }
        }

        public FormularioCrearIncidenciaViewModel()
        {
             
        }

        public FormularioCrearIncidenciaViewModel(DashboardViewModel dashboardViewModel)
        {
            _obj = dashboardViewModel;
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
                _obj.mostrarVistaIncidencias();
            }
        }

        public void volverAVistaIncidencias()
        {
            
        }
    }
}
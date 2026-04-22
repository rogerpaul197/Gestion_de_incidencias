using System.Collections.ObjectModel;
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
        private string _categoria;
        private string _prioridad;
        public ObservableCollection<string> CategoriasComboBox { get; set; }
        public ObservableCollection<string> PrioridadesComboBox { get; set; }
        private DashboardViewModel _obj;

        public ObservableCollection<Categoria> Categorias { get; set; }

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

        public string Categoria
        {
            get { return _categoria; }
            set
            {
                _categoria = value;
                OnPropertyChanged();
            }
        }

        public string CategoriaPlaceholder
        {
            get { return "Seleccione categoría"; }
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
            Categorias = new ObservableCollection<Categoria>();
            CategoriasComboBox = new ObservableCollection<string>();
            PrioridadesComboBox = new ObservableCollection<string>();
            CargarCategorias();
            CargarPrioridades();
        }

        public FormularioCrearIncidenciaViewModel(DashboardViewModel dashboardViewModel)
        {
            _obj = dashboardViewModel;
            Categorias = new ObservableCollection<Categoria>();
            CategoriasComboBox = new ObservableCollection<string>();
            PrioridadesComboBox = new ObservableCollection<string>();
            CargarCategorias();
            CargarPrioridades();
        }

        public void CargarCategorias()
        {
            Categorias.Clear();
            CategoriasComboBox.Clear();

            CategoriasComboBox.Add("Seleccione categoría");

            var lista = CategoriaRepository.ObtenerCategorias();

            foreach (var categoria in lista)
            {
                Categorias.Add(categoria);
                CategoriasComboBox.Add(categoria.Nombre);
            }

            Categoria = "Seleccione categoría";
        }

        public void CargarPrioridades()
        {
            PrioridadesComboBox.Clear();

            PrioridadesComboBox.Add("Seleccione prioridad");
            PrioridadesComboBox.Add("Baja");
            PrioridadesComboBox.Add("Media");
            PrioridadesComboBox.Add("Alta");

            Prioridad = "Seleccione prioridad";
        }

        public void crearIncidencia()
        {
            if (string.IsNullOrWhiteSpace(Titulo) || string.IsNullOrWhiteSpace(Descripcion) || string.IsNullOrWhiteSpace(Prioridad) || string.IsNullOrWhiteSpace(Categoria) || Categoria == "Seleccione categoría" || Prioridad == "Seleccione prioridad")
            {
                MessageBox.Show("Por favor, complete todos los campos para crear la incidencia.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Incidencia incidencia = new Incidencia(Titulo, Descripcion, Categoria, Prioridad);
                IncidenciaRepository.RegistrarIncidencia(incidencia);
                MessageBox.Show("Incidencia registrada.");
                _obj.mostrarVistaIncidencias();
            }
        }

        public void volverAVistaIncidencias()
        {
            _obj.mostrarVistaIncidencias();
        }
    }
}
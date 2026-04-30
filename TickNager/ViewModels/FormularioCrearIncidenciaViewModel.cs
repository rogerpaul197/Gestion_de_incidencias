/// <summary>
/// Esta clase se encarga de la lógica para crear una nueva incidencia.
/// </summary>

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TickNager.Helper;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class FormularioCrearIncidenciaViewModel : INotifyPropertyChanged
    {
        private string _titulo;
        private string _descripcion;
        private string _categoria;
        private string _prioridad;
        private DashboardViewModel _obj;

        public ObservableCollection<string> CategoriasComboBox { get; set; }
        public ObservableCollection<string> PrioridadesComboBox { get; set; }
        public ObservableCollection<Categoria> Categorias { get; set; }

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

        /// <summary>
        /// Constructor vacío de FormularioCrearIncidenciaViewModel.
        /// </summary>
        public FormularioCrearIncidenciaViewModel()
        {
            Categorias = new ObservableCollection<Categoria>();
            CategoriasComboBox = new ObservableCollection<string>();
            PrioridadesComboBox = new ObservableCollection<string>();

            CargarCategorias();
            CargarPrioridades();
        }

        /// <summary>
        /// Constructor que recibe el ViewModel principal para poder cambiar de vista.
        /// </summary>
        /// <param name="dashboardViewModel">ViewModel principal del dashboard.</param>
        public FormularioCrearIncidenciaViewModel(DashboardViewModel dashboardViewModel) : this()
        {
            _obj = dashboardViewModel;
        }

        /// <summary>
        /// Esta función carga las categorías disponibles para el ComboBox.
        /// </summary>
        public void CargarCategorias()
        {
            Categorias.Clear();
            CategoriasComboBox.Clear();

            CategoriasComboBox.Add("Seleccione categoría");

            var lista = CategoriaRepository.ObtenerCategorias();

            for (int i = 0; i < lista.Count; i++)
            {
                Categorias.Add(lista[i]);
                CategoriasComboBox.Add(lista[i].Nombre);
            }

            Categoria = "Seleccione categoría";
        }

        /// <summary>
        /// Esta función carga las prioridades disponibles para el ComboBox.
        /// </summary>
        public void CargarPrioridades()
        {
            PrioridadesComboBox.Clear();

            PrioridadesComboBox.Add("Seleccione prioridad");
            PrioridadesComboBox.Add("Baja");
            PrioridadesComboBox.Add("Media");
            PrioridadesComboBox.Add("Alta");

            Prioridad = "Seleccione prioridad";
        }

        /// <summary>
        /// Esta función crea una incidencia nueva y la guarda en la base de datos.
        /// </summary>
        public void crearIncidencia()
        {
            if (Titulo == null || Titulo == "" || Descripcion == null || Descripcion == "" || Prioridad == null || Prioridad == "" || Categoria == null || Categoria == "" || Categoria == "Seleccione categoría" || Prioridad == "Seleccione prioridad")
            {
                MessageBox.Show("Por favor, complete todos los campos para crear la incidencia.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Incidencia incidencia = new Incidencia(Titulo, Descripcion, Categoria, Prioridad);

            incidencia.Estado = "Pendiente";
            incidencia.IdUsuario = SesionUsuarioHelper.UsuarioActual.Id;
            incidencia.UsuarioReportero = SesionUsuarioHelper.UsuarioActual.NombreCompleto;

            IncidenciaRepository.RegistrarIncidencia(incidencia);

            MessageBox.Show("Incidencia registrada.");

            _obj.mostrarVistaIncidencias();
        }

        /// <summary>
        /// Esta función vuelve a la vista de incidencias.
        /// </summary>
        public void volverAVistaIncidencias()
        {
            _obj.mostrarVistaIncidencias();
        }

        /// <summary>
        /// Evento que avisa a la vista cuando cambia una propiedad del ViewModel.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Esta función notifica a la vista que una propiedad cambió.
        /// </summary>
        /// <param name="nombrePropiedad">Nombre de la propiedad que cambió.</param>
        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
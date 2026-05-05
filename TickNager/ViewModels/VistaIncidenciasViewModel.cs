/// <summary>
/// Esta clase se encarga de cargar, filtrar y mostrar las incidencias según el usuario actual.
/// </summary>

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TickNager.Helper;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class VistaIncidenciasViewModel : INotifyPropertyChanged
    {
        private DashboardViewModel _obj;
        private List<Incidencia> _todasLasIncidencias;

        private string _textoBusqueda;
        private string _prioridadSeleccionada;
        private string _estadoSeleccionado;
        private string _categoriaSeleccionada;

        public ObservableCollection<Incidencia> Incidencias { get; set; }
        public ObservableCollection<string> PrioridadesFiltro { get; set; }
        public ObservableCollection<string> EstadosFiltro { get; set; }
        public ObservableCollection<string> CategoriasFiltro { get; set; }
        public ObservableCollection<Usuario> Tecnicos { get; set; }

        public string TextoBusqueda
        {
            get { return _textoBusqueda; }
            set
            {
                _textoBusqueda = value;
                OnPropertyChanged();
                AplicarFiltros();
            }
        }

        public string PrioridadSeleccionada
        {
            get { return _prioridadSeleccionada; }
            set
            {
                _prioridadSeleccionada = value;
                OnPropertyChanged();
                AplicarFiltros();
            }
        }

        public string EstadoSeleccionado
        {
            get { return _estadoSeleccionado; }
            set
            {
                _estadoSeleccionado = value;
                OnPropertyChanged();
                AplicarFiltros();
            }
        }

        public string CategoriaSeleccionada
        {
            get { return _categoriaSeleccionada; }
            set
            {
                _categoriaSeleccionada = value;
                OnPropertyChanged();
                AplicarFiltros();
            }
        }

        /// <summary>
        /// Constructor vacío que inicializa las colecciones y carga los datos.
        /// </summary>
        public VistaIncidenciasViewModel()
        {
            Incidencias = new ObservableCollection<Incidencia>();
            PrioridadesFiltro = new ObservableCollection<string>();
            EstadosFiltro = new ObservableCollection<string>();
            CategoriasFiltro = new ObservableCollection<string>();
            Tecnicos = new ObservableCollection<Usuario>();
            _todasLasIncidencias = new List<Incidencia>();

            CargarFiltros();
            CargarIncidencias();
            CargarTecnicos();
        }

        /// <summary>
        /// Constructor que recibe el ViewModel principal.
        /// </summary>
        /// <param name="dashboardViewModel">ViewModel principal del dashboard.</param>
        public VistaIncidenciasViewModel(DashboardViewModel dashboardViewModel) : this()
        {
            _obj = dashboardViewModel;
        }

        /// <summary>
        /// Esta función carga los filtros de prioridad, estado y categoría.
        /// </summary>
        public void CargarFiltros()
        {
            PrioridadesFiltro.Clear();
            EstadosFiltro.Clear();
            CategoriasFiltro.Clear();

            PrioridadesFiltro.Add("Todas");
            PrioridadesFiltro.Add("Baja");
            PrioridadesFiltro.Add("Media");
            PrioridadesFiltro.Add("Alta");

            EstadosFiltro.Add("Todos");
            EstadosFiltro.Add("Pendiente");
            EstadosFiltro.Add("Asignada");
            EstadosFiltro.Add("En proceso");
            EstadosFiltro.Add("Pendiente de validación");
            EstadosFiltro.Add("Resuelta");

            CategoriasFiltro.Add("Todas");

            var categorias = CategoriaRepository.ObtenerCategorias();

            for (int i = 0; i < categorias.Count; i++)
            {
                CategoriasFiltro.Add(categorias[i].Nombre);
            }

            PrioridadSeleccionada = "Todas";
            EstadoSeleccionado = "Todos";
            CategoriaSeleccionada = "Todas";
            TextoBusqueda = "";
        }

        /// <summary>
        /// Esta función carga las incidencias según el rol del usuario actual.
        /// </summary>
        public void CargarIncidencias()
        {
            Incidencias.Clear();
            _todasLasIncidencias.Clear();

            var usuarioActual = SesionUsuarioHelper.UsuarioActual;

            List<Incidencia> lista;

            if (usuarioActual.RolUsuario == "Administrador")
            {
                lista = IncidenciaRepository.ObtenerIncidencias();
            }
            else if (usuarioActual.RolUsuario == "Técnico")
            {
                lista = IncidenciaRepository.ObtenerIncidenciasPorTecnico(usuarioActual.Id);
            }
            else
            {
                lista = IncidenciaRepository.ObtenerIncidenciasPorUsuario(usuarioActual.Id);
            }

            for (int i = 0; i < lista.Count; i++)
            {
                _todasLasIncidencias.Add(lista[i]);
            }

            AplicarFiltros();
        }

        /// <summary>
        /// Esta función aplica los filtros seleccionados a la lista de incidencias.
        /// </summary>
        public void AplicarFiltros()
        {
            Incidencias.Clear();

            for (int i = 0; i < _todasLasIncidencias.Count; i++)
            {
                Incidencia incidencia = _todasLasIncidencias[i];

                bool coincideTexto = TextoBusqueda == null || TextoBusqueda == "" || incidencia.Titulo.ToLower().Contains(TextoBusqueda.ToLower()) || incidencia.Descripcion.ToLower().Contains(TextoBusqueda.ToLower()) || (incidencia.Categoria != null && incidencia.Categoria.ToLower().Contains(TextoBusqueda.ToLower()));
                bool coincidePrioridad = PrioridadSeleccionada == "Todas" || incidencia.Prioridad == PrioridadSeleccionada;
                bool coincideEstado = EstadoSeleccionado == "Todos" || incidencia.Estado == EstadoSeleccionado;
                bool coincideCategoria = CategoriaSeleccionada == "Todas" || incidencia.Categoria == CategoriaSeleccionada;

                if (coincideTexto && coincidePrioridad && coincideEstado && coincideCategoria)
                {
                    Incidencias.Add(incidencia);
                }
            }
        }

        /// <summary>
        /// Esta función limpia todos los filtros.
        /// </summary>
        public void LimpiarFiltros()
        {
            TextoBusqueda = "";
            PrioridadSeleccionada = "Todas";
            EstadoSeleccionado = "Todos";
            CategoriaSeleccionada = "Todas";

            AplicarFiltros();
        }

        /// <summary>
        /// Esta función carga los técnicos disponibles.
        /// </summary>
        public void CargarTecnicos()
        {
            Tecnicos.Clear();

            var lista = TecnicoRepository.ObtenerTecnicos();

            for (int i = 0; i < lista.Count; i++)
            {
                Tecnicos.Add(lista[i]);
            }
        }

        /// <summary>
        /// Evento que avisa a la vista cuando cambia una propiedad.
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TickNager.Models;
using TickNager.Repositories;
using TickNager.Helper;

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

        public VistaIncidenciasViewModel()
        {
            Incidencias = new ObservableCollection<Incidencia>();
            PrioridadesFiltro = new ObservableCollection<string>();
            EstadosFiltro = new ObservableCollection<string>();
            CategoriasFiltro = new ObservableCollection<string>();
            _todasLasIncidencias = new List<Incidencia>();

            CargarFiltros();
            CargarIncidencias();

            Tecnicos = new ObservableCollection<Usuario>();
            CargarTecnicos();
        }

        public VistaIncidenciasViewModel(DashboardViewModel dashboardViewModel)
        {
            _obj = dashboardViewModel;
            Incidencias = new ObservableCollection<Incidencia>();
            PrioridadesFiltro = new ObservableCollection<string>();
            EstadosFiltro = new ObservableCollection<string>();
            CategoriasFiltro = new ObservableCollection<string>();
            _todasLasIncidencias = new List<Incidencia>();

            CargarFiltros();
            CargarIncidencias();

            Tecnicos = new ObservableCollection<Usuario>();
            CargarTecnicos();
        }

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
            EstadosFiltro.Add("En proceso");
            EstadosFiltro.Add("Resuelta");

            CategoriasFiltro.Add("Todas");

            var categorias = CategoriaRepository.ObtenerCategorias();

            foreach (var categoria in categorias)
            {
                CategoriasFiltro.Add(categoria.Nombre);
            }

            PrioridadSeleccionada = "Todas";
            EstadoSeleccionado = "Todos";
            CategoriaSeleccionada = "Todas";
            TextoBusqueda = "";
        }

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

            foreach (var incidencia in lista)
            {
                _todasLasIncidencias.Add(incidencia);
            }

            AplicarFiltros();
        }

        public void AplicarFiltros()
        {
            Incidencias.Clear();

            foreach (var incidencia in _todasLasIncidencias)
            {
                bool coincideTexto = string.IsNullOrWhiteSpace(TextoBusqueda)
                    || incidencia.Titulo.ToLower().Contains(TextoBusqueda.ToLower())
                    || incidencia.Descripcion.ToLower().Contains(TextoBusqueda.ToLower())
                    || (incidencia.Categoria != null && incidencia.Categoria.ToLower().Contains(TextoBusqueda.ToLower()));

                bool coincidePrioridad = PrioridadSeleccionada == "Todas"
                    || incidencia.Prioridad == PrioridadSeleccionada;

                bool coincideEstado = EstadoSeleccionado == "Todos"
                    || incidencia.Estado == EstadoSeleccionado;

                bool coincideCategoria = CategoriaSeleccionada == "Todas"
                    || incidencia.Categoria == CategoriaSeleccionada;

                if (coincideTexto && coincidePrioridad && coincideEstado && coincideCategoria)
                {
                    Incidencias.Add(incidencia);
                }
            }
        }

        public void LimpiarFiltros()
        {
            TextoBusqueda = "";
            PrioridadSeleccionada = "Todas";
            EstadoSeleccionado = "Todos";
            CategoriaSeleccionada = "Todas";

            AplicarFiltros();
        }

        public void CargarTecnicos()
        {
            Tecnicos.Clear();

            var lista = TecnicoRepository.ObtenerTecnicos();

            foreach (var tecnico in lista)
            {
                Tecnicos.Add(tecnico);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
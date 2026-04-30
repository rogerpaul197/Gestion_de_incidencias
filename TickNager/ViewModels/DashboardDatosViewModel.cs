/// <summary>
/// Esta clase se encarga de cargar los datos y gráficos que se muestran en el Dashboard.
/// </summary>

using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class DashboardDatosViewModel : INotifyPropertyChanged
    {
        private int _totalIncidencias;
        private int _incidenciasPendientes;
        private int _incidenciasEnProceso;
        private int _totalUsuarios;
        private int _incidenciasAsignadas;
        private int _incidenciasResueltas;

        public SeriesCollection SeriesPrioridades { get; set; }
        public SeriesCollection SeriesEstados { get; set; }
        public SeriesCollection SeriesTendencia { get; set; }
        public string[] LabelsPrioridad { get; set; } = { "" };
        public string[] LabelsTendencia { get; set; }

        public int TotalIncidencias
        {
            get { return _totalIncidencias; }
            set
            {
                _totalIncidencias = value;
                OnPropertyChanged();
            }
        }

        public int IncidenciasPendientes
        {
            get { return _incidenciasPendientes; }
            set
            {
                _incidenciasPendientes = value;
                OnPropertyChanged();
            }
        }

        public int IncidenciasEnProceso
        {
            get { return _incidenciasEnProceso; }
            set
            {
                _incidenciasEnProceso = value;
                OnPropertyChanged();
            }
        }

        public int TotalUsuarios
        {
            get { return _totalUsuarios; }
            set
            {
                _totalUsuarios = value;
                OnPropertyChanged();
            }
        }

        public int IncidenciasAsignadas
        {
            get { return _incidenciasAsignadas; }
            set
            {
                _incidenciasAsignadas = value;
                OnPropertyChanged();
            }
        }

        public int IncidenciasResueltas
        {
            get { return _incidenciasResueltas; }
            set
            {
                _incidenciasResueltas = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Constructor que carga los datos principales y los gráficos.
        /// </summary>
        public DashboardDatosViewModel()
        {
            CargarDatos();
            CargarGraficoPrioridades();
            CargarGraficoEstados();
            CargarGraficoTendencia();
        }

        /// <summary>
        /// Esta función carga los datos numéricos del dashboard.
        /// </summary>
        public void CargarDatos()
        {
            TotalIncidencias = IncidenciaRepository.ObtenerTotalIncidencias();
            IncidenciasPendientes = IncidenciaRepository.ObtenerIncidenciasPendientes();
            IncidenciasAsignadas = IncidenciaRepository.ObtenerIncidenciasAsignadas();
            IncidenciasEnProceso = IncidenciaRepository.ObtenerIncidenciasEnProceso();
            IncidenciasResueltas = IncidenciaRepository.ObtenerIncidenciasResueltas();
            TotalUsuarios = UsuarioRepository.ObtenerTotalUsuarios();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Esta función avisa a la vista cuando cambia una propiedad.
        /// </summary>
        /// <param name="nombrePropiedad">Nombre de la propiedad que cambió.</param>
        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }

        /// <summary>
        /// Esta función carga el gráfico de incidencias por prioridad.
        /// </summary>
        public void CargarGraficoPrioridades()
        {
            int baja = IncidenciaRepository.ObtenerIncidenciasPorPrioridad("Baja");
            int media = IncidenciaRepository.ObtenerIncidenciasPorPrioridad("Media");
            int alta = IncidenciaRepository.ObtenerIncidenciasPorPrioridad("Alta");

            SeriesPrioridades = new SeriesCollection();

            ColumnSeries serieBaja = new ColumnSeries();
            serieBaja.Title = "Baja";
            serieBaja.Values = new ChartValues<int>();
            serieBaja.Values.Add(baja);
            serieBaja.Values.Add(0);
            serieBaja.Values.Add(0);
            serieBaja.Fill = new SolidColorBrush(Color.FromRgb(34, 197, 94));
            serieBaja.MaxColumnWidth = 45;

            ColumnSeries serieMedia = new ColumnSeries();
            serieMedia.Title = "Media";
            serieMedia.Values = new ChartValues<int>();
            serieMedia.Values.Add(0);
            serieMedia.Values.Add(media);
            serieMedia.Values.Add(0);
            serieMedia.Fill = new SolidColorBrush(Color.FromRgb(245, 158, 11));
            serieMedia.MaxColumnWidth = 45;

            ColumnSeries serieAlta = new ColumnSeries();
            serieAlta.Title = "Alta";
            serieAlta.Values = new ChartValues<int>();
            serieAlta.Values.Add(0);
            serieAlta.Values.Add(0);
            serieAlta.Values.Add(alta);
            serieAlta.Fill = new SolidColorBrush(Color.FromRgb(239, 68, 68));
            serieAlta.MaxColumnWidth = 45;

            SeriesPrioridades.Add(serieBaja);
            SeriesPrioridades.Add(serieMedia);
            SeriesPrioridades.Add(serieAlta);

            LabelsPrioridad = new string[] { "Baja", "Media", "Alta" };

            OnPropertyChanged(nameof(SeriesPrioridades));
            OnPropertyChanged(nameof(LabelsPrioridad));
        }

        /// <summary>
        /// Esta función carga el gráfico de incidencias por estado.
        /// </summary>
        public void CargarGraficoEstados()
        {
            int pendientes = IncidenciaRepository.ObtenerIncidenciasPorEstado("Pendiente");
            int asignadas = IncidenciaRepository.ObtenerIncidenciasPorEstado("Asignada");
            int enProceso = IncidenciaRepository.ObtenerIncidenciasPorEstado("En proceso");
            int resueltas = IncidenciaRepository.ObtenerIncidenciasPorEstado("Resuelta");

            SeriesEstados = new SeriesCollection();

            PieSeries seriePendiente = new PieSeries();
            seriePendiente.Title = "Pendiente";
            seriePendiente.Values = new ChartValues<int>();
            seriePendiente.Values.Add(pendientes);
            seriePendiente.DataLabels = true;

            PieSeries serieAsignada = new PieSeries();
            serieAsignada.Title = "Asignada";
            serieAsignada.Values = new ChartValues<int>();
            serieAsignada.Values.Add(asignadas);
            serieAsignada.DataLabels = true;

            PieSeries serieEnProceso = new PieSeries();
            serieEnProceso.Title = "En proceso";
            serieEnProceso.Values = new ChartValues<int>();
            serieEnProceso.Values.Add(enProceso);
            serieEnProceso.DataLabels = true;

            PieSeries serieResuelta = new PieSeries();
            serieResuelta.Title = "Resuelta";
            serieResuelta.Values = new ChartValues<int>();
            serieResuelta.Values.Add(resueltas);
            serieResuelta.DataLabels = true;

            SeriesEstados.Add(seriePendiente);
            SeriesEstados.Add(serieAsignada);
            SeriesEstados.Add(serieEnProceso);
            SeriesEstados.Add(serieResuelta);

            OnPropertyChanged(nameof(SeriesEstados));
        }

        /// <summary>
        /// Esta función carga el gráfico de tendencia de incidencias por fecha.
        /// </summary>
        public void CargarGraficoTendencia()
        {
            var datos = IncidenciaRepository.ObtenerIncidenciasPorFecha();

            List<string> fechas = new List<string>();
            ChartValues<int> cantidades = new ChartValues<int>();

            foreach (var item in datos)
            {
                fechas.Add(item.Key);
                cantidades.Add(item.Value);
            }

            SeriesTendencia = new SeriesCollection();

            LineSeries serieTendencia = new LineSeries();
            serieTendencia.Title = "Incidencias";
            serieTendencia.Values = cantidades;
            serieTendencia.PointGeometrySize = 10;

            SeriesTendencia.Add(serieTendencia);

            LabelsTendencia = fechas.ToArray();

            OnPropertyChanged(nameof(SeriesTendencia));
            OnPropertyChanged(nameof(LabelsTendencia));
        }
    }
}
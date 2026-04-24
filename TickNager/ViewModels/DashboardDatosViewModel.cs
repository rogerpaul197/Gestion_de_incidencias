using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TickNager.Repositories;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace TickNager.ViewModels
{
    public class DashboardDatosViewModel : INotifyPropertyChanged
    {
        private int _totalIncidencias;
        private int _incidenciasPendientes;
        private int _incidenciasEnProceso;
        private int _totalUsuarios;
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

        public DashboardDatosViewModel()
        {
            CargarDatos();
            CargarGraficoPrioridades();
            CargarGraficoEstados();
            CargarGraficoTendencia();
        }

        public void CargarDatos()
        {
            TotalIncidencias = IncidenciaRepository.ObtenerTotalIncidencias();
            IncidenciasPendientes = IncidenciaRepository.ObtenerIncidenciasPendientes();
            IncidenciasEnProceso = IncidenciaRepository.ObtenerIncidenciasEnProceso();
            TotalUsuarios = UsuarioRepository.ObtenerTotalUsuarios();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }

        public void CargarGraficoPrioridades()
        {
            int baja = IncidenciaRepository.ObtenerIncidenciasPorPrioridad("Baja");
            int media = IncidenciaRepository.ObtenerIncidenciasPorPrioridad("Media");
            int alta = IncidenciaRepository.ObtenerIncidenciasPorPrioridad("Alta");

            SeriesPrioridades = new SeriesCollection
    {
        new ColumnSeries
        {
            Title = "Baja",
            Values = new ChartValues<int> { baja, 0, 0 },
            Fill = new SolidColorBrush(Color.FromRgb(34, 197, 94)),
            MaxColumnWidth = 45
        },
        new ColumnSeries
        {
            Title = "Media",
            Values = new ChartValues<int> { 0, media, 0 },
            Fill = new SolidColorBrush(Color.FromRgb(245, 158, 11)),
            MaxColumnWidth = 45
        },
        new ColumnSeries
        {
            Title = "Alta",
            Values = new ChartValues<int> { 0, 0, alta },
            Fill = new SolidColorBrush(Color.FromRgb(239, 68, 68)),
            MaxColumnWidth = 45
        }
    };

            LabelsPrioridad = new string[] { "Baja", "Media", "Alta" };

            OnPropertyChanged(nameof(SeriesPrioridades));
            OnPropertyChanged(nameof(LabelsPrioridad));
        }

        public void CargarGraficoEstados()
        {
            int pendientes = IncidenciaRepository.ObtenerIncidenciasPendientesGrafico();
            int enProceso = IncidenciaRepository.ObtenerIncidenciasPorEstado("En proceso");

            SeriesEstados = new SeriesCollection
    {
        new PieSeries
        {
            Title = "Pendiente",
            Values = new ChartValues<int> { pendientes },
            DataLabels = true
        },
        new PieSeries
        {
            Title = "En proceso",
            Values = new ChartValues<int> { enProceso },
            DataLabels = true
        }
    };

            OnPropertyChanged(nameof(SeriesEstados));
        }

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

            SeriesTendencia = new SeriesCollection
    {
        new LineSeries
        {
            Title = "Incidencias",
            Values = cantidades,
            PointGeometrySize = 10
        }
    };

            LabelsTendencia = fechas.ToArray();

            OnPropertyChanged(nameof(SeriesTendencia));
            OnPropertyChanged(nameof(LabelsTendencia));
        }
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace TickNager.Models
{
    public class Incidencia : INotifyPropertyChanged
    {
        private int _id;
        private string _tituloIncidencia;
        private string _descripcionIncidencia;

        /// <summary>
        /// Alta , Media, Baja
        /// </summary>
        private string _prioridadIncidencia;

        private string _estado = "Pendiente";
        private DateTime _fechaCreacion;
        private DateTime? _fechaCierre;
        
        private string? _categoriaIncidencia;
        private string _usuarioReportero;
        private string _tecnicoAsignado;

        private int _idReportero;
        private int _idTecnico;
        private int _idCategoria;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Titulo
        { 
            get { return _tituloIncidencia; } 
            set { _tituloIncidencia = value; }
        }

        public string Descripcion
        {
            get { return _descripcionIncidencia; }
            set { _descripcionIncidencia = value; }
        }

        public string Prioridad
        {
            get { return _prioridadIncidencia; }
            set { _prioridadIncidencia = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set
            {
                _estado = value;
                OnPropertyChanged();
            }
        }

        public string FechaCreacion
        {
            get
            {
                return _fechaCreacion.ToString("dd/MM/yyyy");
            }
        }

        public DateTime? FechaCierre
        {
            get { return _fechaCierre; }
            set { _fechaCierre = value; }
        }

        public string? CategoriaIncidencia
        {
            get { return _categoriaIncidencia; }
            set { _categoriaIncidencia = value; }
        }

        public string UsuarioReportero
        {
            get { return _usuarioReportero; }
            set { _usuarioReportero = value; }
        }

        public string TecnicoAsignado
        {
            get { return _tecnicoAsignado; }
            set { _tecnicoAsignado = value; }
        }

        public int IdReportero
        {
            get { return _idReportero; }
            set { _idReportero = value; }
        }

        public int IdTecnico
        {
            get { return _idTecnico; }
            set { _idTecnico = value; }
        }

        public int IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }

        public Incidencia()
        {
            _estado = "Pendiente";
            _fechaCreacion = DateTime.Now;
        }

        //Cuándo el usuario reporte la incidencia sólo asigna la descripción
        public Incidencia(string descripcionIncidencia)
        {
            _descripcionIncidencia = descripcionIncidencia;
            _estado = "Pendiente";
            _fechaCreacion = DateTime.Now;
        }

        //El administrador la usa al asignar a un técnico
        public Incidencia(string tituloIncidencia, string tecnicoAsignado, string usuarioReporta)
        {
            _tituloIncidencia = tituloIncidencia;
            _estado = "Pendiente"; 
            _tecnicoAsignado = tecnicoAsignado;
            _usuarioReportero = usuarioReporta;
            _fechaCreacion = DateTime.Now;
            _descripcionIncidencia = "";
        }

        public Incidencia(string tituloIncidencia, string descripcionIncidencia, string? categoriaIncidencia, string prioridadIncidencia)
        {
            _tituloIncidencia = tituloIncidencia;
            _descripcionIncidencia = descripcionIncidencia;
            _categoriaIncidencia = categoriaIncidencia;
            _prioridadIncidencia = prioridadIncidencia;
            _estado = "Pendiente";
            _fechaCreacion = DateTime.Now;
        }

        public void AsignarFechaCreacion(DateTime fecha)
        {
            _fechaCreacion = fecha;
            OnPropertyChanged(nameof(FechaCreacion));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace TickNager.Models
{
    public class Incidencia : INotifyPropertyChanged
    {
        private int _id;
        private int _idUsuario;
        private int _idTecnico;
        private int _idCategoria;
        private string _estado = "Pendiente";
        private string _tituloIncidencia;
        private string? _categoriaIncidencia;
        private string _usuarioReportero;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
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

        public string UsuarioReportero
        {
            get { return _usuarioReportero; }
            set { _usuarioReportero = value; }
        }

        /// <summary>
        /// Alta , Media, Baja
        /// </summary>
        private string _prioridadIncidencia;

        /// True --> incidencia asignada
        /// False --> incidencia no asignada        
        private bool _estadoIncidencia = false;

        /// True --> incidencia acabada
        /// False --> incidencia no acabada 
        /// La decide el técnico al acabarlo o no
        private bool _incidenciaTerminada = false;

        /// True --> incidencia en proceso
        /// False --> incidencia no está en proceso
        /// La decide el técnico cuándo empieza a resolver la incidencia
        private bool _incidenciaEnProceso = false;

        private string _tecnicoAsignado_equipoAsignado;

        //Usuario que reporta la incidencia
        private string _usuarioReporta;

        //Aquí el usuario describe las incidencias
        private string _descripcionIncidencia;
        private DateTime _fechaRegistro = DateTime.Now;

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

        public string? Categoria
        {
            get { return _categoriaIncidencia; }
            set { _categoriaIncidencia = value; }
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

        public string FechaRegistro
        {
            get
            {
                return _fechaRegistro.ToString("dd/MM/yyyy");
            }
        }

        public Incidencia()
        {

        }

        //Cuándo el usuario reporte la incidencia sólo asigna la descripción
        public Incidencia(string descripcionIncidencia)
        {
            _descripcionIncidencia = descripcionIncidencia;
        }

        //El administrador la usa al asignar a un técnico
        public Incidencia(string tituloIncidencia, string tecnicoAsignado_equipoAsignado, string usuarioReporta)
        {
            _tituloIncidencia = tituloIncidencia;
            _estadoIncidencia = true; //Incidencia asignada al crearla, ya que al crear se debe asignar a un responsable
            _tecnicoAsignado_equipoAsignado = tecnicoAsignado_equipoAsignado;
            _usuarioReporta = usuarioReporta;
            _fechaRegistro = DateTime.Now;
            _descripcionIncidencia = null;
        }

        public Incidencia(string tituloIncidencia, string descripcionIncidenci, string? categoriaIncidencia, string prioridadIncidencia)
        {
            _tituloIncidencia = tituloIncidencia;
            _descripcionIncidencia = descripcionIncidenci;
            _categoriaIncidencia = categoriaIncidencia;
            _prioridadIncidencia = prioridadIncidencia;
        }

        public void AsignarFechaRegistro(DateTime fecha)
        {
            _fechaRegistro = fecha;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}

namespace TickNager.Models
{
    public class Incidencia
    {
        private string _tituloIncidencia;
        private string? _categoriaIncidencia;

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
        private DateTime _fechaCreacion;

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
            _fechaCreacion = DateTime.Now;
            _descripcionIncidencia = null;
        }

        public Incidencia(string tituloIncidencia, string descripcionIncidenci, string? categoriaIncidencia, string prioridadIncidencia)
        {
            _tituloIncidencia = tituloIncidencia;
            _descripcionIncidencia = descripcionIncidenci;
            _categoriaIncidencia = categoriaIncidencia;
            _prioridadIncidencia = prioridadIncidencia;
        }
    }
}

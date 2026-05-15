namespace TickNager.Models
{
    public class Comentario
    {
        private int _id;
        private int _idIncidencia;
        private string _usuario;
        private string _mensaje;
        private string _fecha;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int IdIncidencia
        {
            get { return _idIncidencia; }
            set { _idIncidencia = value; }
        }

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public bool EsUsuarioActual { get; set; }

        public Comentario()
        {

        }

        public Comentario(int idIncidencia, string usuario, string mensaje, string fecha)
        {
            _idIncidencia = idIncidencia;
            _usuario = usuario;
            _mensaje = mensaje;
            _fecha = fecha;
        }
    }
}
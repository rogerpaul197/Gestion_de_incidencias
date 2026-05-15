namespace TickNager.Models
{
    public class Notificacion
    {
        private int _id;
        private string _mensaje;
        private bool _leido;
        private string _fecha;
        private int _idUsuario;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public bool Leido
        {
            get { return _leido; }
            set { _leido = value; }
        }

        public string Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public Notificacion()
        {

        }

        public Notificacion(string mensaje, int idUsuario)
        {
            _mensaje = mensaje;
            _idUsuario = idUsuario;
            _leido = false;
        }
    }
}
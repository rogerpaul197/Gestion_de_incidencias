namespace TickNager.Models
{
    public class Categoria
    {
        private int _id;
        private string _nombre;
        private string _descripcion;
        private bool _activo;
        private int _cantidadIncidencias;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        public int CantidadIncidencias
        {
            get { return _cantidadIncidencias; }
            set { _cantidadIncidencias = value; }
        }

        public string TextoCantidadIncidencias
        {
            get
            {
                if (CantidadIncidencias == 1)
                {
                    return "1 incidencia";
                }
                else
                {
                    return CantidadIncidencias + " incidencias";
                }
            }
        }

        public Categoria()
        {

        }

        public Categoria(string nombre, string descripcion)
        {
            _nombre = nombre;
            _descripcion = descripcion;

            //Se pondrá activo por defecto al crearse
            _activo = true;

            //Cada categoría creada tendrá 0 incidencias
            _cantidadIncidencias = 0;
        }
    }
}

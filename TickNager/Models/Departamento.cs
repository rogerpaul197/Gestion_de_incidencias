namespace TickNager.Models
{
    public class Departamento
    {
        private int _id;
        private string _nombre;

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

        public Departamento()
        {
        }

        public Departamento(string nombre)
        {
            _nombre = nombre;
        }
    }
}
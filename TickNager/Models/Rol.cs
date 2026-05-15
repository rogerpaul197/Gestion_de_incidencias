namespace TickNager.Models
{
    public class Rol
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

        public Rol()
        { 
        }

        public Rol(string nombre)
        {
            Nombre = nombre;
        }
    }
}

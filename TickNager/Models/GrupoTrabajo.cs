namespace TickNager.Models
{
    public class GrupoTrabajo
    {
        private int _id;
        private string _nombreDepartamento;
        private int _cantidadMiembros;
        private bool _puedeGestionar;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string NombreDepartamento
        {
            get { return _nombreDepartamento; }
            set { _nombreDepartamento = value; }
        }

        public int CantidadMiembros
        {
            get { return _cantidadMiembros; }
            set { _cantidadMiembros = value; }
        }

        public bool PuedeGestionar
        {
            get { return _puedeGestionar; }
            set { _puedeGestionar = value; }
        }

        public string TextoMiembros
        {
            get
            {
                if (CantidadMiembros == 1)
                {
                    return "1 miembro";
                }
                else
                {
                    return CantidadMiembros + " miembros";
                }
            }
        }

        public GrupoTrabajo()
        {

        }
    }
}
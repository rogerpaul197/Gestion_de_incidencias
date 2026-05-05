namespace TickNager.Models
{
    public class GrupoTrabajo
    {
        public int Id { get; set; }
        public string NombreDepartamento { get; set; }
        public int CantidadMiembros { get; set; }
        public bool PuedeGestionar { get; set; }

        public string TextoMiembros
        {
            get
            {
                if (CantidadMiembros == 1)
                {
                    return "1 miembro";
                }

                return CantidadMiembros + " miembros";
            }
        }
    }
}
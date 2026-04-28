namespace TickNager.Models
{
    public class Notificacion
    {
        public int Id { get; set; }
        public int IdUsuarioDestino { get; set; }
        public string Mensaje { get; set; }
        public bool Leida { get; set; }
        public string Fecha { get; set; }

        public Notificacion()
        {
        }
    }
}
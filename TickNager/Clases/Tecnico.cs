namespace TickNager.Clases
{
    public class Tecnico
    {
        public Tecnico()
        {

        }

        public void incidenciaEnProceso(Incidencia incidencia)
        {
            incidencia.setIncidenciaEnProceso();
        }

        /// <summary>
        /// El técnico cuándo termina de resolver una incidencia
        /// </summary>
        /// <param name="incidencia">Acepta incidencias para cambiar su estado de "incidenciaTerminada" de False a True</param>
        public void incidenciaTerminada(Incidencia incidencia)
        {
            incidencia.setIncidenciaTreminada();
        }
    }
}

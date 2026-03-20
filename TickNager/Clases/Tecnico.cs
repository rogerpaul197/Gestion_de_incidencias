namespace TickNager.Clases
{
    public class Tecnico
    {

        //Se utilizan para poder asignar una imagen masculino o femenino
        public bool esHombre = true;
        public bool esMujer = true;

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
<<<<<<< HEAD
}
=======
}
>>>>>>> fa9368ce1a14ebc4361b27f62a1a0a947ee3ab22

using System;
using System.Collections.Generic;
using System.Text;

namespace TickNager.Clases
{
    public class Incidencia
    {
        public string nombreIncidencia;

        /// True --> incidencia asignada
        /// False --> incidencia no asignada        
        public bool estadoIncidencia = false;

        /// True --> incidencia acabada
        /// False --> incidencia no acabada 
        /// La decide el técnico al acabarlo o no
        public bool incidenciaTerminada = false;

        /// True --> incidencia en proceso
        /// False --> incidencia no está en proceso
        /// La decide el técnico cuándo empieza a resolver la incidencia
        public bool incidenciaEnProceso = false;

        public string tecnicoAsignado_equipoAsignado;
        public string usuarioReporta;
        public DateTime fechaCreacion;

        public Incidencia()
        {

        }

        //Si la incidencia es sólo para un técnico
        public Incidencia(string nombreIncidencia, string tecnicoAsignado_equipoAsignado, string usuarioReporta)
        {
            this.nombreIncidencia = nombreIncidencia;
            estadoIncidencia = true; //Incidencia asignada al crearla, ya que al crear se debe asignar a un responsable
            this.tecnicoAsignado_equipoAsignado = tecnicoAsignado_equipoAsignado;
            this.usuarioReporta = usuarioReporta;
            fechaCreacion = DateTime.Now;
        }

        public void setIncidenciaTreminada()
        {
            incidenciaTerminada = true;
        }

        public void setIncidenciaEnProceso()
        {
            incidenciaEnProceso = true;
        }
    }
}

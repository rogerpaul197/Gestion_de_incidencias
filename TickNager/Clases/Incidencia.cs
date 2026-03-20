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

        //Usuario que reporta la incidencia
        public string usuarioReporta;

        //Aquí el usuario describe las incidencias
        public string descripcionIncidencia;
        public DateTime fechaCreacion;

        public Incidencia()
        {

        }

        //Cuándo el usuario reporte la incidencia sólo asigna la descripción
        public Incidencia(string descripcionIncidencia)
        {
            this.descripcionIncidencia = descripcionIncidencia;
        }

        //El administrador la usa al asignar a un técnico
        public Incidencia(string nombreIncidencia, string tecnicoAsignado_equipoAsignado, string usuarioReporta)
        {
            this.nombreIncidencia = nombreIncidencia;
            estadoIncidencia = true; //Incidencia asignada al crearla, ya que al crear se debe asignar a un responsable
            this.tecnicoAsignado_equipoAsignado = tecnicoAsignado_equipoAsignado;
            this.usuarioReporta = usuarioReporta;
            fechaCreacion = DateTime.Now;
            descripcionIncidencia = null;
        }

        public void setIncidenciaTreminada()
        {
            incidenciaTerminada = true;
        }

        public void setIncidenciaEnProceso()
        {
            incidenciaEnProceso = true;
        }

        public void setDescripcionIncidencias()
        {

        }
    }
}
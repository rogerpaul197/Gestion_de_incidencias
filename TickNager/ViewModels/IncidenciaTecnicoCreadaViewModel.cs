using System.Windows;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class IncidenciaTecnicoCreadaViewModel
    {
        public void VerDetalle(object obj)
        {
            Incidencia incidencia = obj as Incidencia;

            if (incidencia == null)
            {
                return;
            }

            MessageBox.Show("Título: " + incidencia.Titulo +
                            "\n\nDescripción: " + incidencia.Descripcion +
                            "\n\nCategoría: " + incidencia.Categoria +
                            "\n\nPrioridad: " + incidencia.Prioridad +
                            "\n\nEstado: " + incidencia.Estado,
                            "Detalle de incidencia");
        }

        public void MarcarEnProceso(object obj)
        {
            Incidencia incidencia = obj as Incidencia;

            if (incidencia == null)
            {
                return;
            }

            IncidenciaRepository.ActualizarEstadoIncidencia(incidencia.Id, "En proceso");

            incidencia.Estado = "En proceso";

            MessageBox.Show("Incidencia marcada como En proceso.");
        }

        public void MarcarResuelta(object obj)
        {
            Incidencia incidencia = obj as Incidencia;

            if (incidencia == null)
            {
                return;
            }

            IncidenciaRepository.ActualizarEstadoIncidencia(incidencia.Id, "Resuelta");

            incidencia.Estado = "Resuelta";

            MessageBox.Show("Incidencia marcada como Resuelta.");
        }
    }
}
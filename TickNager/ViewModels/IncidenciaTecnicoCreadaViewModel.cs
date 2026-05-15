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

            DashboardViewModel.obj.mostrarVistaDetalleIncidencia(incidencia);
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

            IncidenciaRepository.ActualizarEstadoIncidencia(incidencia.Id, "Pendiente de validación");

            incidencia.Estado = "Pendiente de validación";

            MessageBox.Show("Incidencia enviada para validación del administrador.");
        }
    }
}
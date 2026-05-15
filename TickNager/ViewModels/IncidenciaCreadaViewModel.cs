using System.Windows;
using TickNager.Models;
using TickNager.Repositories;
using TickNager.Views.Windows;

namespace TickNager.ViewModels
{
    public class IncidenciaCreadaViewModel
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

        public void AsignarTecnico(object obj)
        {
            Incidencia incidencia = obj as Incidencia;

            if (incidencia == null)
            {
                return;
            }

            AsignarTecnicoWindow ventana = new AsignarTecnicoWindow(incidencia.Id);
            ventana.ShowDialog();

            if (ventana.AsignacionRealizada)
            {
                incidencia.Estado = "Asignada";
            }
        }

        public void ValidarIncidencia(object obj)
        {
            Incidencia incidencia = obj as Incidencia;

            if (incidencia == null)
            {
                return;
            }

            if (incidencia.Estado != "Pendiente de validación")
            {
                MessageBox.Show("Solo se pueden validar incidencias pendientes de validación.");
                return;
            }

            IncidenciaRepository.ActualizarEstadoIncidencia(incidencia.Id, "Resuelta");

            incidencia.Estado = "Resuelta";

            MessageBox.Show("Incidencia validada correctamente.");
        }

        public void ReabrirIncidencia(object obj)
        {
            Incidencia incidencia = obj as Incidencia;

            if (incidencia == null)
            {
                return;
            }

            if (incidencia.Estado != "Pendiente de validación")
            {
                MessageBox.Show("Solo se pueden reabrir incidencias pendientes de validación.");
                return;
            }

            IncidenciaRepository.ActualizarEstadoIncidencia(incidencia.Id, "En proceso");

            incidencia.Estado = "Pendiente";

            MessageBox.Show("La incidencia se ha devuelto al técnico.");
        }
    }
}
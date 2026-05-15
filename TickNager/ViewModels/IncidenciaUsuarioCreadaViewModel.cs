using TickNager.Models;

namespace TickNager.ViewModels
{
    public class IncidenciaUsuarioCreadaViewModel
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

        public void EditarIncidencia(object obj)
        {
            Incidencia incidencia = obj as Incidencia;

            if (incidencia == null)
            {
                return;
            }

            DashboardViewModel.obj.mostrarVistaEditarIncidencia(incidencia);
        }
    }
}
using System.Windows;
using TickNager.Models;
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

            MessageBox.Show("Título: " + incidencia.Titulo + "\n\nDescripción: " + incidencia.Descripcion + "\n\nCategoría: " + incidencia.Categoria + "\n\nPrioridad: " + incidencia.Prioridad + "Detalle de incidencia");
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
    }
}
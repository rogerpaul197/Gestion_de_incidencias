using System.Windows;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class GrupoTrabajoCreadoViewModel
    {
        public void RenombrarGrupo(object obj)
        {
            GrupoTrabajo grupo = obj as GrupoTrabajo;

            if (grupo == null)
            {
                return;
            }

            string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox("Nuevo nombre del grupo:", "Renombrar grupo", grupo.NombreDepartamento);

            if (nuevoNombre == null || nuevoNombre == "")
            {
                return;
            }

            GrupoTrabajoRepository.RenombrarGrupo(grupo.Id, grupo.NombreDepartamento, nuevoNombre);

            MessageBox.Show("Grupo actualizado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            DashboardViewModel.obj.mostrarVistaGrupoTrabajo();
        }

        public void EliminarGrupo(object obj)
        {
            GrupoTrabajo grupo = obj as GrupoTrabajo;

            if (grupo == null)
            {
                return;
            }

            MessageBoxResult resultado = MessageBox.Show("¿Seguro que quieres eliminar este grupo?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (resultado == MessageBoxResult.Yes)
            {
                GrupoTrabajoRepository.EliminarGrupo(grupo.Id, grupo.NombreDepartamento);

                MessageBox.Show("Grupo eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                DashboardViewModel.obj.mostrarVistaGrupoTrabajo();
            }
        }
    }
}
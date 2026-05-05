using System.Collections.ObjectModel;
using System.Windows;
using TickNager.Helper;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class VistaGruposTrabajoViewModel
    {
        public ObservableCollection<GrupoTrabajo> GruposTrabajo { get; set; }

        public string NombreGrupo { get; set; }

        private DashboardViewModel _dashboardViewModel;

        public bool EsAdmin
        {
            get
            {
                if (SesionUsuarioHelper.UsuarioActual != null)
                {
                    if (SesionUsuarioHelper.UsuarioActual.RolUsuario == "Administrador")
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public VistaGruposTrabajoViewModel(DashboardViewModel dashboardViewModel)
        {
            _dashboardViewModel = dashboardViewModel;
            GruposTrabajo = new ObservableCollection<GrupoTrabajo>();
            CargarGruposTrabajo();
        }

        public void CargarGruposTrabajo()
        {
            GruposTrabajo.Clear();

            var lista = GrupoTrabajoRepository.ObtenerGrupos();

            for (int i = 0; i < lista.Count; i++)
            {
                lista[i].PuedeGestionar = EsAdmin;
                GruposTrabajo.Add(lista[i]);
            }
        }

        public void CrearGrupo()
        {
            if (NombreGrupo == null || NombreGrupo == "")
            {
                MessageBox.Show("Escribe el nombre del grupo.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            GrupoTrabajoRepository.CrearGrupo(NombreGrupo);

            MessageBox.Show("Grupo creado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            NombreGrupo = "";

            CargarGruposTrabajo();
        }

        public void RenombrarGrupo(object obj)
        {
            GrupoTrabajo grupo = obj as GrupoTrabajo;

            if (grupo == null)
            {
                return;
            }

            if (NombreGrupo == null || NombreGrupo == "")
            {
                MessageBox.Show("Escribe el nuevo nombre del grupo.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            GrupoTrabajoRepository.RenombrarGrupo(grupo.Id, grupo.NombreDepartamento, NombreGrupo);

            MessageBox.Show("Grupo actualizado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            NombreGrupo = "";

            CargarGruposTrabajo();
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

                CargarGruposTrabajo();
            }
        }

        public void MostrarFormularioCrearGrupo()
        {
            _dashboardViewModel.mostrarFormularioCrearGrupoTrabajo();
        }
    }
}
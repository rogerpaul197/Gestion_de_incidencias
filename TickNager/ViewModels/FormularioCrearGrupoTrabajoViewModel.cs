using System.Collections.ObjectModel;
using System.Windows;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class FormularioCrearGrupoTrabajoViewModel
    {
        private DashboardViewModel _dashboardViewModel;

        public string NombreGrupo { get; set; }
        public ObservableCollection<Usuario> Usuarios { get; set; }
        public ObservableCollection<Usuario> UsuariosSeleccionados { get; set; }

        public FormularioCrearGrupoTrabajoViewModel(DashboardViewModel dashboardViewModel)
        {
            _dashboardViewModel = dashboardViewModel;

            Usuarios = new ObservableCollection<Usuario>();
            UsuariosSeleccionados = new ObservableCollection<Usuario>();

            CargarUsuarios();
        }

        public void CargarUsuarios()
        {
            Usuarios.Clear();

            var lista = UsuarioRepository.ObtenerUsuarios();

            for (int i = 0; i < lista.Count; i++)
            {
                Usuarios.Add(lista[i]);
            }
        }

        public void GuardarGrupo()
        {
            if (NombreGrupo == null || NombreGrupo == "")
            {
                MessageBox.Show("Escribe el nombre del grupo.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            GrupoTrabajoRepository.CrearGrupo(NombreGrupo);

            for (int i = 0; i < UsuariosSeleccionados.Count; i++)
            {
                GrupoTrabajoRepository.AsignarUsuarioAGrupo(UsuariosSeleccionados[i].Id, NombreGrupo);
            }

            MessageBox.Show("Grupo creado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            _dashboardViewModel.mostrarVistaGrupoTrabajo();
        }

        public void Cancelar()
        {
            _dashboardViewModel.mostrarVistaGrupoTrabajo();
        }
    }
}
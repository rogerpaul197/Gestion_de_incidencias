using System.Collections.ObjectModel;
using System.Windows;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class VistaEditarIncidenciaViewModel
    {
        private DashboardViewModel _dashboardViewModel;
        private Incidencia _incidencia;

        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Prioridad { get; set; }

        public ObservableCollection<string> CategoriasComboBox { get; set; }
        public ObservableCollection<string> PrioridadesComboBox { get; set; }

        public VistaEditarIncidenciaViewModel(DashboardViewModel dashboardViewModel, Incidencia incidencia)
        {
            _dashboardViewModel = dashboardViewModel;
            _incidencia = incidencia;

            Titulo = incidencia.Titulo;
            Descripcion = incidencia.Descripcion;
            Categoria = incidencia.CategoriaIncidencia;
            Prioridad = incidencia.Prioridad;

            CategoriasComboBox = new ObservableCollection<string>();
            PrioridadesComboBox = new ObservableCollection<string>();

            CargarCategorias();
            CargarPrioridades();
        }

        public void CargarCategorias()
        {
            CategoriasComboBox.Clear();

            var lista = CategoriaRepository.ObtenerCategorias();

            for (int i = 0; i < lista.Count; i++)
            {
                CategoriasComboBox.Add(lista[i].Nombre);
            }
        }

        public void CargarPrioridades()
        {
            PrioridadesComboBox.Clear();

            PrioridadesComboBox.Add("Baja");
            PrioridadesComboBox.Add("Media");
            PrioridadesComboBox.Add("Alta");
        }

        public void Guardar()
        {
            if (Titulo == null || Titulo == "" || Descripcion == null || Descripcion == "" || Categoria == null || Categoria == "" || Prioridad == null || Prioridad == "")
            {
                MessageBox.Show("Completa todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int idCategoria = CategoriaRepository.ObtenerIdCategoria(Categoria);

            if (idCategoria == 0)
            {
                MessageBox.Show("La categoría seleccionada no existe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _incidencia.Titulo = Titulo;
            _incidencia.Descripcion = Descripcion;
            _incidencia.CategoriaIncidencia = Categoria;
            _incidencia.Prioridad = Prioridad;
            _incidencia.IdCategoria = idCategoria;

            IncidenciaRepository.ActualizarIncidenciaUsuario(_incidencia);

            MessageBox.Show("Incidencia actualizada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            _dashboardViewModel.mostrarVistaIncidencias();
        }

        public void Cancelar()
        {
            _dashboardViewModel.mostrarVistaIncidencias();
        }
    }
}
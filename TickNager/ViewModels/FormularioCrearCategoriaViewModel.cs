/// <summary>
/// Esta clase se encarga de la lógica para crear una nueva categoría.
/// </summary>

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class FormularioCrearCategoriaViewModel
    {
        private string _titulo;
        private string _descripcion;
        private string _imagenCategoria = "/Imagenes/Iconos/interrogacion_por_defecto.png";
        private DashboardViewModel _obj;

        public string Titulo
        {
            get { return _titulo; }
            set
            {
                _titulo = value;
                OnPropertyChanged();
            }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = value;
                OnPropertyChanged();
            }
        }

        public string ImagenCategoria
        {
            get { return _imagenCategoria; }
            set
            {
                _imagenCategoria = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Constructor vacío de FormularioCrearCategoriaViewModel.
        /// </summary>
        public FormularioCrearCategoriaViewModel()
        {
        }

        /// <summary>
        /// Constructor que recibe el ViewModel principal para poder cambiar de vista.
        /// </summary>
        /// <param name="obj">ViewModel principal del dashboard.</param>
        public FormularioCrearCategoriaViewModel(DashboardViewModel obj)
        {
            _obj = obj;
        }

        /// <summary>
        /// Esta función crea una nueva categoría y la guarda en la base de datos.
        /// </summary>
        public void CrearCategoria()
        {
            if (Titulo == null || Titulo == "")
            {
                MessageBox.Show("El título de la categoría es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Categoria categoriaNueva = new Categoria(Titulo, Descripcion);

            CategoriaRepository.RegistrarCategoria(categoriaNueva);

            MessageBox.Show("Categoría creada correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            _obj.mostrarVistaCategorias();
        }

        /// <summary>
        /// Evento que avisa a la vista cuando cambia una propiedad del ViewModel.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Esta función notifica a la vista que una propiedad cambió.
        /// </summary>
        /// <param name="nombrePropiedad">Nombre de la propiedad que cambió.</param>
        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
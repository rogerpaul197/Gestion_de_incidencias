using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class FormularioCrearCategoriaViewModel
    {
        private string _titulo;
        private string _descripcion;
        private string _imagenCategoria = "/Imagenes/Iconos/Empresa.png";
        private DashboardViewModel _obj;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }

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

        public FormularioCrearCategoriaViewModel()
        {
        }

        public FormularioCrearCategoriaViewModel(DashboardViewModel obj)
        {
            _obj = obj;
        }

        public void CrearCategoria()
        {
            if (string.IsNullOrWhiteSpace(Titulo))
            {
                MessageBox.Show("El título de la categoría es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Categoria categoriaNueva = new Categoria(Titulo, Descripcion);
            CategoriaRepository.RegistrarCategoria(categoriaNueva);

            MessageBox.Show("Categoría creada correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            _obj.mostrarVistaCategorias();
        }
    }
}

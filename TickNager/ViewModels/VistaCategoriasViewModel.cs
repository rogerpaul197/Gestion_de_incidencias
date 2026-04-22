using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class VistaCategoriasViewModel
    {
        private DashboardViewModel _obj;

        public ObservableCollection<Categoria> Categorias { get; set; }

        public VistaCategoriasViewModel()
        {
            Categorias = new ObservableCollection<Categoria>();
            CargarCategorias();
        }

        public VistaCategoriasViewModel(DashboardViewModel obj)
        {
            _obj = obj;
            Categorias = new ObservableCollection<Categoria>();
            CargarCategorias();
        }

        public void CargarCategorias()
        {
            Categorias.Clear();

            var lista = CategoriaRepository.ObtenerCategorias();

            foreach (var categoria in lista)
            {
                Categorias.Add(categoria);
            }
        }
    }
}
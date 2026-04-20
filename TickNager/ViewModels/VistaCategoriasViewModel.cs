using System;
using System.Collections.Generic;
using System.Text;
using TickNager.Models;

namespace TickNager.ViewModels
{
    public class VistaCategoriasViewModel
    {
        private DashboardViewModel _obj;

        public List<Categoria> Categorias { get; set; }

        public VistaCategoriasViewModel()
        {
            Categorias = new List<Categoria>();
        }

        public VistaCategoriasViewModel(DashboardViewModel obj)
        {
            _obj = obj;
            Categorias = new List<Categoria>();
        }
    }
}
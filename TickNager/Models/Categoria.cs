using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TickNager.Models
{
    public class Categoria
    {
        private string _nombre;
        private string _descripcion;
        private bool _activo;
        private int _cantidadIncidencias;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
            }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = value;
            }
        }

        public bool Activo
        {
            get { return _activo; }
            set
            {
                _activo = value;
            }
        }

        public int CantidadIncidencias
        {
            get { return _cantidadIncidencias;  }
            set
            {
                if (CantidadIncidencias >= 0)
                {
                    _cantidadIncidencias = value;
                } else
                {
                    MessageBox.Show("Las incidencias no pueden ser menor que 0", "Error:", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public Categoria()
        {

        }

        public Categoria(string nombre, string descripcion)
        {
            _nombre = nombre;
            _descripcion = descripcion;

            //Se pondrá activo por defecto al crearse
            _activo = true;

            //Cada categoría creada tendrá 0 incidencias
            _cantidadIncidencias = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class FormularioCrearIncidencia
    {
        private string _titulo;
        private string _descripcion;
        private string _categoria;
        private string _Prioridad;

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public string Prioridad
        {
            get { return _Prioridad; }
            set { _Prioridad = value; }
        }

        public void crearIncidencia()
        {
            //si los campos están vacíos, no se puede crear la incidencia
            if (Titulo == null || Descripcion == null || Categoria == null || Prioridad == null)
            {
                MessageBox.Show("Por favor, complete todos los campos para crear la incidencia.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                Incidencia incidencia = new Incidencia(Titulo, Descripcion, Categoria, Prioridad);
                //IncidenciaRepository.RegistrarIncidencia(incidencia);
                MessageBox.Show("Usuario registrado exitosamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TickNager.Models;

namespace TickNager.ViewModels
{
    public class VistaDetalleIncidenciaViewModel
    {
        private DashboardViewModel _dashboardViewModel;
        private Incidencia _incidencia;

        public string Titulo
        {
            get { return _incidencia.Titulo; }
        }

        public string Descripcion
        {
            get { return _incidencia.Descripcion; }
        }

        public string Categoria
        {
            get { return _incidencia.CategoriaIncidencia; }
        }

        public string Prioridad
        {
            get { return _incidencia.Prioridad; }
        }

        public string Estado
        {
            get { return _incidencia.Estado; }
        }

        public string UsuarioReportero
        {
            get { return _incidencia.UsuarioReportero; }
        }

        public string TecnicoAsignado
        {
            get
            {
                if (_incidencia.TecnicoAsignado == null || _incidencia.TecnicoAsignado == "")
                {
                    return "Sin técnico asignado";
                }

                return _incidencia.TecnicoAsignado;
            }
        }

        public string FechaCreacion
        {
            get { return "Creación: " + _incidencia.FechaCreacion; }
        }

        public string FechaCierre
        {
            get
            {
                if (_incidencia.FechaCierre == null)
                {
                    return "Fecha de cierre: Aún no resuelta";
                }

                return "Fecha de cierre: " + _incidencia.FechaCierre.Value.ToString("dd/MM/yyyy");
            }
        }

        public VistaDetalleIncidenciaViewModel(DashboardViewModel dashboardViewModel, Incidencia incidencia)
        {
            _dashboardViewModel = dashboardViewModel;
            _incidencia = incidencia;
        }

        public void Volver()
        {
            _dashboardViewModel.mostrarVistaIncidencias();
        }
    }
}

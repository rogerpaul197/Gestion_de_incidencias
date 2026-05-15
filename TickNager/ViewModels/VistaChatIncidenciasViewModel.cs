using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TickNager.Helper;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class VistaChatIncidenciasViewModel : INotifyPropertyChanged
    {
        private Incidencia _incidenciaSeleccionada;
        private string _nuevoComentario;

        public ObservableCollection<Incidencia> Incidencias { get; set; }
        public ObservableCollection<Comentario> Comentarios { get; set; }

        public Incidencia IncidenciaSeleccionada
        {
            get { return _incidenciaSeleccionada; }
            set
            {
                _incidenciaSeleccionada = value;
                OnPropertyChanged();
                CargarComentarios();
            }
        }

        public string NuevoComentario
        {
            get { return _nuevoComentario; }
            set
            {
                _nuevoComentario = value;
                OnPropertyChanged();
            }
        }

        public VistaChatIncidenciasViewModel()
        {
            Incidencias = new ObservableCollection<Incidencia>();
            Comentarios = new ObservableCollection<Comentario>();

            CargarIncidencias();
        }

        public void CargarIncidencias()
        {
            Incidencias.Clear();

            var usuarioActual = SesionUsuarioHelper.UsuarioActual;

            if (usuarioActual.RolUsuario == "Administrador")
            {
                var lista = IncidenciaRepository.ObtenerIncidencias();

                for (int i = 0; i < lista.Count; i++)
                {
                    Incidencias.Add(lista[i]);
                }
            }
            else if (usuarioActual.RolUsuario == "Técnico")
            {
                var lista = IncidenciaRepository.ObtenerIncidenciasPorTecnico(usuarioActual.Id);

                for (int i = 0; i < lista.Count; i++)
                {
                    Incidencias.Add(lista[i]);
                }
            }
            else
            {
                var lista = IncidenciaRepository.ObtenerIncidenciasPorUsuario(usuarioActual.Id);

                for (int i = 0; i < lista.Count; i++)
                {
                    Incidencias.Add(lista[i]);
                }
            }
        }

        public void CargarComentarios()
        {
            Comentarios.Clear();

            if (IncidenciaSeleccionada == null)
            {
                return;
            }

            var lista = ComentarioRepository.ObtenerComentarios(IncidenciaSeleccionada.Id);

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Usuario == SesionUsuarioHelper.UsuarioActual.NombreCompleto)
                {
                    lista[i].EsUsuarioActual = true;
                }

                Comentarios.Add(lista[i]);
            }
        }

        public void CrearComentario()
        {
            if (IncidenciaSeleccionada == null)
            {
                return;
            }

            if (NuevoComentario == null || NuevoComentario == "")
            {
                return;
            }

            Comentario comentario = new Comentario();

            comentario.IdIncidencia = IncidenciaSeleccionada.Id;
            comentario.Usuario = SesionUsuarioHelper.UsuarioActual.NombreCompleto;
            comentario.Mensaje = NuevoComentario;
            comentario.Fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            ComentarioRepository.CrearComentario(comentario);

            NuevoComentario = "";

            CargarComentarios();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
/// <summary>
/// Esta clase se encarga de la lógica para asignar un técnico a una incidencia.
/// </summary>

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class AsignarTecnicoWindowViewModel : INotifyPropertyChanged
    {
        private int _idIncidencia;
        private Usuario _tecnicoSeleccionado;

        public ObservableCollection<Usuario> Tecnicos { get; set; }

        public Usuario TecnicoSeleccionado
        {
            get { return _tecnicoSeleccionado; }
            set
            {
                _tecnicoSeleccionado = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Constructor que recibe la incidencia a la que se le asignará un técnico.
        /// </summary>
        /// <param name="idIncidencia">Id de la incidencia seleccionada.</param>
        public AsignarTecnicoWindowViewModel(int idIncidencia)
        {
            _idIncidencia = idIncidencia;
            Tecnicos = new ObservableCollection<Usuario>();

            CargarTecnicos();
        }

        /// <summary>
        /// Esta función carga todos los técnicos disponibles.
        /// </summary>
        public void CargarTecnicos()
        {
            Tecnicos.Clear();

            var lista = TecnicoRepository.ObtenerTecnicos();

            for (int i = 0; i < lista.Count; i++)
            {
                Tecnicos.Add(lista[i]);
            }
        }

        /// <summary>
        /// Esta función asigna el técnico seleccionado a la incidencia.
        /// </summary>
        /// <returns>Devuelve true si se asignó correctamente, si no devuelve false.</returns>
        public bool AsignarTecnico()
        {
            if (TecnicoSeleccionado == null)
            {
                MessageBox.Show("Selecciona un técnico primero", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            AdministradorRepository.AsignarTecnico(_idIncidencia, TecnicoSeleccionado.Id);

            MessageBox.Show("Técnico asignado correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Esta función avisa a la vista cuando cambia una propiedad.
        /// </summary>
        /// <param name="nombrePropiedad">Nombre de la propiedad que cambió.</param>
        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
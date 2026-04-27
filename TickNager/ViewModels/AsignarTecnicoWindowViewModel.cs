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

        public AsignarTecnicoWindowViewModel(int idIncidencia)
        {
            _idIncidencia = idIncidencia;
            Tecnicos = new ObservableCollection<Usuario>();

            CargarTecnicos();
        }

        public void CargarTecnicos()
        {
            Tecnicos.Clear();

            var lista = TecnicoRepository.ObtenerTecnicos();

            foreach (var tecnico in lista)
            {
                Tecnicos.Add(tecnico);
            }
        }

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

        protected void OnPropertyChanged([CallerMemberName] string nombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class AsignarTecnicoWindowViewModel
    {
        private int _idIncidencia;

        public ObservableCollection<Usuario> Tecnicos { get; set; }

        public Usuario TecnicoSeleccionado { get; set; }

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

        public void SeleccionarTecnico(object sender)
        {
            RadioButton radio = sender as RadioButton;

            if (radio != null)
            {
                TecnicoSeleccionado = radio.DataContext as Usuario;
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
    }
}
// GestionUsuariosViewModel.cs
using System.Collections.ObjectModel;
using System.Windows.Input;
using TickNager.Models;

namespace TickNager.ViewModels
{
    public class GestionUsuariosViewModel
    {
        public ObservableCollection<Usuario> Usuarios { get; set; }

        public ICommand AnadirUsuarioCommand { get; set; }

        public GestionUsuariosViewModel()
        {
            Usuarios = new ObservableCollection<Usuario>();
            AnadirUsuarioCommand = new RelayCommand(AnadirUsuario);
        }

        private void AnadirUsuario(object parametro)
        {
            Usuarios.Add(new Usuario(
                "Carlos",
                "Pérez",
                "Informática",
                "600123456",
                "carlos@ticknager.com",
                "1234"
            ));
        }
    }
}
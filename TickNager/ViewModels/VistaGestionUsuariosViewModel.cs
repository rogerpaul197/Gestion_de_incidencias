using System.Collections.ObjectModel;
using TickNager.Models;
using TickNager.Repositories;

namespace TickNager.ViewModels
{
    public class VistaGestionUsuariosViewModel
    {
        public ObservableCollection<Usuario> Usuarios { get; set; }

        public VistaGestionUsuariosViewModel()
        {
            Usuarios = new ObservableCollection<Usuario>();
            CargarUsuarios();
        }

        public void CargarUsuarios()
        {
            Usuarios.Clear();

            var lista = UsuarioRepository.ObtenerUsuarios();

            for (int i = 0; i < lista.Count; i++)
            {
                Usuarios.Add(lista[i]);
            }
        }
    }
}

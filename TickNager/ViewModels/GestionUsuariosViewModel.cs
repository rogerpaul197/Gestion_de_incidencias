// GestionUsuariosViewModel.cs
using System.Collections.ObjectModel;
using System.Windows.Input;
using TickNager.Models;

namespace TickNager.ViewModels
{
    public class GestionUsuariosViewModel
    {
        //Lista de usuarios
        ObservableCollection<Usuario> usuarios { get; set; }
        public ICommand anadirUsuarioCommand { get; set; }
        
        public GestionUsuariosViewModel()
        {

        }

        public Usuario crearUsuario()
        {
            Usuario usuarioNuevo = new Usuario();
            return usuarioNuevo;
        }
    }
}
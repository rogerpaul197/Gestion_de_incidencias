using System.Windows;
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.UserControls
{
    public partial class UsuarioCreado : UserControl
    {
        private UsuarioCreadoViewModel _obj;

        public UsuarioCreado()
        {
            InitializeComponent();
            _obj = new UsuarioCreadoViewModel();
        }

        private void menuVerPerfil_Click(object sender, RoutedEventArgs e)
        {
            _obj.VerPerfil(DataContext);
        }

        private void menuCambiarRol_Click(object sender, RoutedEventArgs e)
        {
            _obj.CambiarRol(DataContext);
        }

        private void menuEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            _obj.EliminarUsuario(DataContext);

            if (_obj.usuarioEliminado)
            {
                Visibility = Visibility.Collapsed;
            }
        }
    }
}
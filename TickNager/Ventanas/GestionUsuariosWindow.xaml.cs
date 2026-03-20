using System.Windows;
using TickNager.Ventanas;
<<<<<<< HEAD
using TickNager.Vista.ControladoresUsuario;
=======
>>>>>>> fa9368ce1a14ebc4361b27f62a1a0a947ee3ab22

namespace TickNager
{
    /// <summary>
    /// Lógica de interacción para GestionUsuariosWindow.xaml
    /// </summary>
    public partial class GestionUsuariosWindow : Window
    {
        public GestionUsuariosWindow()
        {
            InitializeComponent();
        }

        private void btnAnadirUsuario_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            CrearUsuarioWindow ventana = new CrearUsuarioWindow(this);
            ventana.Show();
        }

        public void AgregarUsuarioCreado(string nombreCompleto)
        {
            var usuario = new Vista.ControladoresUsuario.UsuarioCreado(nombreCompleto);
            spUsuarios.Children.Add(usuario);
        }
    }
}
=======
            CrearUsuarioWindow ventana = new CrearUsuarioWindow();
            ventana.Show();
        }
    }
}
>>>>>>> fa9368ce1a14ebc4361b27f62a1a0a947ee3ab22

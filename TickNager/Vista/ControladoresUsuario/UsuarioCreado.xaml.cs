using System.Windows.Controls;

namespace TickNager.Vista.ControladoresUsuario
{
    /// <summary>
    /// Lógica de interacción para UsuarioCreado.xaml
    /// </summary>
    public partial class UsuarioCreado : UserControl
    {
        public UsuarioCreado(string nombreCompleto)
        {
            InitializeComponent();
            tbNombreUsuario.Text = nombreCompleto;
        }
    }
}

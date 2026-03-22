using System.Windows;

namespace TickNager.Views
{
    /// <summary>
    /// Lógica de interacción para AvisoCampoVacioWindow.xaml
    /// </summary>
    public partial class AvisoCampoVacioWindow : Window
    {
        public AvisoCampoVacioWindow()
        {
            InitializeComponent();
        }

        private void btnAvisoCampoVacio_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

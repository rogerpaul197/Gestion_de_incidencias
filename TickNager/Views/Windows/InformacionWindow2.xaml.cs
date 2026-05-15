using System.Windows;

namespace TickNager.Views.Windows
{
    /// <summary>
    /// Lógica de interacción para InformacionWindow2.xaml
    /// </summary>
    public partial class InformacionWindow2 : Window
    {
        public InformacionWindow2()
        {
            InitializeComponent();
        }

        private void btnEntendido_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

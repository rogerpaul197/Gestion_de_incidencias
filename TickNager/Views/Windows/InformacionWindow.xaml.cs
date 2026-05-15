using System.Windows;

namespace TickNager.Views.Windows
{
    /// <summary>
    /// Lógica de interacción para InformacionWindow.xaml
    /// </summary>
    public partial class InformacionWindow : Window
    {
        public InformacionWindow()
        {
            InitializeComponent();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            InformacionWindow2 ventana2 = new InformacionWindow2();
            ventana2.Show();
            this.Close();
        }
    }
}

// GestionUsuariosPage.xaml.cs
using System.Windows.Controls;
using TickNager.ViewModels;

namespace TickNager.Views.Pages
{
    public partial class GestionUsuariosPage : Page
    {
        public GestionUsuariosPage()
        {
            InitializeComponent();
            DataContext = new GestionUsuariosViewModel();
        }
    }
}
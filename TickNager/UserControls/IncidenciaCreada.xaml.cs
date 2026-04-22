using System.Windows;
using System.Windows.Controls;
using TickNager.Models;

namespace TickNager.UserControls
{
    public partial class IncidenciaCreada : UserControl
    {
        public IncidenciaCreada()
        {
            InitializeComponent();
        }

        private void btnAcciones_Click(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;

            if (boton.ContextMenu != null)
            {
                boton.ContextMenu.PlacementTarget = boton;
                boton.ContextMenu.IsOpen = true;
            }
        }

        private Incidencia ObtenerIncidenciaMenuItem(object sender)
        {
            MenuItem item = sender as MenuItem;
            ContextMenu menu = item?.Parent as ContextMenu;
            FrameworkElement elemento = menu?.PlacementTarget as FrameworkElement;

            if (elemento != null)
            {
                return elemento.DataContext as Incidencia;
            }

            return null;
        }

        private void menuVerDetalle_Click(object sender, RoutedEventArgs e)
        {
            Incidencia incidencia = ObtenerIncidenciaMenuItem(sender);

            if (incidencia != null)
            {
                MessageBox.Show("Título: " + incidencia.Titulo + "\n\nDescripción: " + incidencia.Descripcion + "\n\nCategoría: " + incidencia.Categoria + "\n\nPrioridad: " + incidencia.Prioridad, "Detalle de incidencia");
            }
        }

        private void menuAsignarResponsable_Click(object sender, RoutedEventArgs e)
        {
            Incidencia incidencia = ObtenerIncidenciaMenuItem(sender);

            if (incidencia != null)
            {
                MessageBox.Show("Aquí luego pondremos la lógica para asignar responsable a: " + incidencia.Titulo);
            }
        }
    }
}
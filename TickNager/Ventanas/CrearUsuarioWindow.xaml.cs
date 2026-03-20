<<<<<<< HEAD
﻿using System.Windows;
using TickNager.Clases;
using TickNager.Vista.ControladoresUsuario;
=======
﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
>>>>>>> fa9368ce1a14ebc4361b27f62a1a0a947ee3ab22

namespace TickNager.Ventanas
{
    /// <summary>
<<<<<<< HEAD
=======
<<<<<<<< HEAD:TickNager/Ventanas/RegistroWindow.xaml.cs
    /// Lógica de interacción para RegistroWindow.xaml
    /// </summary>
    public partial class RegistroWindow : Window
    {
        public RegistroWindow()
========
>>>>>>> fa9368ce1a14ebc4361b27f62a1a0a947ee3ab22
    /// Lógica de interacción para CrearUsuarioWindow.xaml
    /// </summary>
    public partial class CrearUsuarioWindow : Window
    {
<<<<<<< HEAD
        private GestionUsuariosWindow ventanaPadre;
        string nombreUsuario;
        string apellidoUsuario;
        string departamentoUsuario;
        string numeroUsuario;
        string correoUsuario;
        string contrasenaUsuario;
        string contrasenaUsuarioConfirmacion;
        string nombreCompleto;
        public CrearUsuarioWindow(GestionUsuariosWindow ventana)
        {
            InitializeComponent();
            ventanaPadre = ventana;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            nombreUsuario = txtNombreUsuario.Text;
            apellidoUsuario = txtApellidoUsuario.Text;

            nombreCompleto = nombreUsuario + " " + apellidoUsuario;

            ventanaPadre.AgregarUsuarioCreado(nombreCompleto);

            this.Close();
=======
        public CrearUsuarioWindow()
>>>>>>>> fa9368ce1a14ebc4361b27f62a1a0a947ee3ab22:TickNager/Ventanas/CrearUsuarioWindow.xaml.cs
        {
            InitializeComponent();
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
>>>>>>> fa9368ce1a14ebc4361b27f62a1a0a947ee3ab22

        }
    }
}

///<summary>
///Nota: El RelayCommand es una clase que implementa la interfaz ICommand, esta clase se utiliza para crear comandos personalizados.
///Permite vincular acciones a eventos de la interfaz de usuario, como clics de botones, y controlar si el comando puede ejecutarse o no (Gracias al canExecute(), 
///si devuelve true, se puede ejecutar la función, si devuelve false, no se puede, sirve cómo para hailitar o deshabilitar botones). El RelayCommand toma dos parámetros: 
///un método de ejecución (Action) y un método de verificación (Predicate) que determina si el comando puede ejecutarse en un momento dado.
///
/// Un ejemplo de uso es con la función en crearUsuario() en el ViewModel, ya que si el usuario es admin, se puede ejecutar (o sea, debe haber una función puedeCrearUsuario()), sino es admin, entonces se deshabilita el botón de crear usuario.
///</summary>
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TickNager.Commands
{
    internal class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Propiedades (1 de tipo Action y otro de tipo Predicado) que toman un objeto, estas propiedades son MÉTODOS
        /// ACCIÓN = MÉTODO
        /// Action --> método que no devuelve nada (debe tomar un objeto)
        /// Predicate --> método que devuelve algo (devuelve booleano/debe tomar un objeto cómo argumento)
        /// </summary>
        private Action<object> _Execute { get; set; }
        private Predicate<object> _CanExecute { get; set; }

        //Este constructor se utiliza para crear un comando sin una función de verificación, lo que significa que el comando siempre se puede ejecutar.
        public RelayCommand(Action<object> ExecuteMethod)
        {
            _Execute = ExecuteMethod;
        }

        //Este constructor se utiliza para crear un comando con una función de verificación, lo que permite controlar si el comando puede ejecutarse o no en función de ciertas condiciones.
        public RelayCommand(Action<object> ExecuteMethod, Predicate<object> CanExecuteMethod)
        {
            _Execute = ExecuteMethod;
            _CanExecute = CanExecuteMethod;
        }

        //2 métodos que se crean sólos al implementar ICommand

        public bool CanExecute(object? parameter)
        {
            return _CanExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _Execute(parameter);
        }
    }
}

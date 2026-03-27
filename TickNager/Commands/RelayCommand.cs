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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kurs_BusinessLayer.Helpers
{
    public class RelayCommand : ICommand
//        Класс реализует два метода:
//CanExecute: определяет, может ли команда выполняться
//Execute: собственно выполняет логику команды
//Событие CanExecuteChanged вызывается при изменении условий, указывающий, может ли команда выполняться.
//Для этого используется событие CommandManager.RequerySuggested.
//Ключевым является метод Execute.Для его выполнения в конструкторе команды передается делегат типа Action<object>.
//При этом класс команды не знает какое именно действие будет выполняться.Например, мы можем написать так:
//var cmd = new RelayCommand(o => { MessageBox.Show("Команда" + o.ToString()); });
//cmd.Execute("1");
//В результате вызова команды будет выведено окно с надписью "Команда1". 
//Но мы могли также передать любое другое действие, которое бы соответствовало делегату Action<object>.
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
            _canExecute = null;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute) : this(execute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}

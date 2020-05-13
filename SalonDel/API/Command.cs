using System;
using System.Windows.Input;

namespace API
{
    class RelayCommand : ICommand
    {
        public Action<object> execute;
        public Func<object, bool> canExecute;

        public RelayCommand(Action<object> action) : this(action, null) { }

        public RelayCommand(Action<object> action, Func<object, bool> canExect)
        {
            execute = action;
            canExecute = canExect;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

            
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
                return canExecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}

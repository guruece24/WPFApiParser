using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WPFApiParser.Command
{
    public class RelayCommand : ICommand
    {
        Func<object, bool> canExecute;
        Action<object> execute;
        bool canExecuteCache;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            else
            {
                return canExecute(parameter);
            }         
        }        

        public void Execute(object parameter)
        {
            execute(parameter);
        }     

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }   
    
    }
}

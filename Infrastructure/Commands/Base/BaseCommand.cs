using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.Infrastructure.Commands.Base
{
    internal abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        //If returns false, command can't be executed
        public abstract bool CanExecute(object? parameter);


        //Command logic
        public abstract void Execute(object? parameter);
    }
}
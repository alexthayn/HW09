using System;
using System.Windows.Input;

namespace HW09.Commands
{
    public class MyCommand : ICommand
    {
        private readonly bool canExecute;
        private readonly Action execute;

        public MyCommand(Action execute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public MyCommand(bool canExecute, Action execute)
        {
            this.canExecute = canExecute;
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        internal void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}

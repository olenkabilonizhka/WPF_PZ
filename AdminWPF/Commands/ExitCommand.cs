using System;
using System.Windows.Input;

namespace AdminWPF
{
    internal class ExitCommand : ICommand
    {
        private LoginViewModel loginVM;

        public ExitCommand(LoginViewModel loginVM)
        {
            this.loginVM = loginVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            loginVM.Exit?.Invoke();
        }
    }
}

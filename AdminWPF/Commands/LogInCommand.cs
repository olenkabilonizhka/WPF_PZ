using System;
using System.Windows.Input;

namespace AdminWPF
{
    internal class LogInCommand : ICommand
    {
        private LoginViewModel loginVM;

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

        public LogInCommand(LoginViewModel loginVM)
        {
            this.loginVM = loginVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (loginVM.LogInButton())
            {
                loginVM.LoginSuccess?.Invoke();
            }
            else
            {
                loginVM.LoginFailed?.Invoke();
            }
        }
    }
}

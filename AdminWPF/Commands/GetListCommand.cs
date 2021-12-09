using System;
using System.Windows.Input;

namespace AdminWPF
{
    internal class GetListCommand : ICommand
    {
        private MainViewModel mainVM;

        public GetListCommand(MainViewModel mainVM)
        {
            this.mainVM = mainVM;
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
            mainVM.GetUsers();
        }
    }
}

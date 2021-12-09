using System;
using System.Windows.Input;

namespace AdminWPF
{
    internal class DeleteCommand : ICommand
    {
        private MainViewModel mainVM;

        public DeleteCommand(MainViewModel mainVM)
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
            return !mainVM.ListSorted;
        }

        public void Execute(object parameter)
        {
            mainVM.Delete();
        }
    }
}

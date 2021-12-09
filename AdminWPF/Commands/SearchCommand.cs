using System;
using System.Windows.Input;

namespace AdminWPF
{
    internal class SearchCommand : ICommand
    {
        private MainViewModel mainVM;

        public SearchCommand(MainViewModel mainVM)
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
            mainVM.Search();
        }
    }
}

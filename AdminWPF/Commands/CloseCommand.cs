using System;
using System.Windows.Input;

namespace AdminWPF
{
    internal class CloseCommand : ICommand
    {
        PersonInfoViewModel personIVM;

        public CloseCommand(PersonInfoViewModel personIVM)
        {
            this.personIVM = personIVM;
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
            if(personIVM.Close())
                personIVM.Closed?.Invoke();
        }
    }
}

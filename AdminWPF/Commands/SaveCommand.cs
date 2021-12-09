using System;
using System.Windows.Input;

namespace AdminWPF
{
    public class SaveCommand : ICommand
    {
        private PersonInfoViewModel personVM;

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

        public SaveCommand(PersonInfoViewModel personVM)
        {
            this.personVM = personVM;
        }

        public bool CanExecute(object parameter)
        {
            return personVM.isValid();
        }

        public void Execute(object parameter)
        {
            personVM.Save();
            personVM.Saved?.Invoke();
        }
    }
}

﻿using System;
using System.Windows.Input;

namespace AdminWPF
{
    internal class InfoCommand : ICommand
    {
        private MainViewModel mainVM;

        public InfoCommand(MainViewModel mainVM)
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
            mainVM.PersonInfo(true);
        }
    }
}
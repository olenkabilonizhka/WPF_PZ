using BLL;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace AdminWPF
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        IAuthManager authManager;
        public ICommand loginCommand { get; set; }
        public ICommand exitCommand { get; set; }

        string email;
        string password;
        public string Email 
        { 
            get 
            { 
                return email; 
            } 
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            private get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel(IAuthManager authManager)
        {
            loginCommand = new LogInCommand(this);
            exitCommand = new ExitCommand(this);
            this.authManager = authManager;
        }

        public bool LogInButton()
        {
            return authManager.Login(email,password);
        }

        public Action LoginSuccess { get; set; }
        public Action LoginFailed { get; set; }
        public Action Exit { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}

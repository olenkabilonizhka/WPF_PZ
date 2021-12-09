using System;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AdminWPF
{
    public class PersonValid : INotifyPropertyChanged, IDataErrorInfo
    {
        string firstname;
        string lastname;
        string email;
        string password;
        public int PersonId { get; set; }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }
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
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? Status { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public DateTime? RowInsertTimeStatus { get; set; }
        public DateTime? RowUpdateTimeStatus { get; set; }

        public bool isEmpty()
        {
            return this.PersonId == 0 && 
                Firstname == null && 
                Lastname == null && 
                Email == null && 
                Password == null && 
                RoleId == 0;
        }

        public bool isValid()
        {
            return String.IsNullOrWhiteSpace(Error);
        }

        string IDataErrorInfo.this[string property]
        {
            get
            {
                return GetErrorInfo(property);
            }
        }

        string GetErrorInfo(string property)
        {
            switch(property)
            {
                case nameof(Firstname):
                    return ValidateFirstName();
                case nameof(Lastname):
                    return ValidateLastName();
                case nameof(Email):
                    return ValidateEmail();
                case nameof(Password):
                    return ValidatePassword();
                default:
                    return null;
            }
        }

        string ValidateFirstName()
        {
            if (String.IsNullOrEmpty(Firstname))
            {
                return "Enter first name";
            }
            if(Firstname.Any(x => Char.IsWhiteSpace(x)))
            {
                return "Can not have white spaces";
            }
            return null;
        }

        string ValidateLastName()
        {
            if (String.IsNullOrEmpty(Lastname))
            {
                return "Enter last name";
            }
            if (Lastname.Any(x => Char.IsWhiteSpace(x)))
            {
                return "Can not have white spaces";
            }
            return null;
        }

        string ValidateEmail()
        {
            if (String.IsNullOrEmpty(Email))
            {
                return "Enter email";
            }
            if (Email.Any(x => Char.IsWhiteSpace(x)))
            {
                return "Can not have white spaces";
            }
            return null;
        }

        string ValidatePassword()
        {
            if (String.IsNullOrEmpty(Password))
            {
                return "Enter password";
            }
            if (Password == "********")
                return null;
            if (Password.Any(x => Char.IsWhiteSpace(x)) || Password.Contains("*"))
            {
                return "Can not have white spaces";
            }
            return null;
        }

        string[] validatedProperties
        {
            get
            {
                return new string[] { 
                    nameof(Firstname), 
                    nameof(Lastname), 
                    nameof(Email), 
                    nameof(Password) 
                };
            }
        }

        public string Error
        {
            get
            {
                StringBuilder strb = new StringBuilder();
                foreach (var item in validatedProperties)
                {
                    var err = GetErrorInfo(item);
                    if (!string.IsNullOrWhiteSpace(err))
                    {
                        strb.AppendLine(err);
                    }
                }
                return strb.ToString();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

    }
}

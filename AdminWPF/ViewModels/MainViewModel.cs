using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace AdminWPF
{
    public class MainViewModel : INotifyPropertyChanged
    {
        IPersonManager personManager;

        PersonDTO person;
        List<PersonDTO> users;
        bool listSorted;
        string searchPerson;
        public string SearchPerson
        {
            get
            {
                return searchPerson;
            }
            set
            {
                searchPerson = value;
                OnPropertyChanged(nameof(SearchPerson));
            }
        }
        public bool ListSorted
        {
            get
            {
                return listSorted;
            }
            set
            {
                listSorted = value;
                OnPropertyChanged(nameof(ListSorted));
            }
        }
        public PersonDTO Person
        {
            get
            {
                return person;
            }
            set
            {
                person = value;
                OnPropertyChanged(nameof(Person));
            }
        }
        public List<PersonDTO> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
        public ICommand activateCommand { get; set; }
        public ICommand blockCommand { get; set; }
        public ICommand addCommand { get; set; }
        public ICommand deleteCommand { get; set; }
        public ICommand sortUsersCommand { get; set; }
        public ICommand getUsersCommand { get; set; }
        public ICommand logoutCommand { get; set; }
        public ICommand searchCommand { get; set; }
        public ICommand showPersonInfoCommand { get; set; }

        public MainViewModel(IPersonManager personManager)
        {
            activateCommand = new ActivateCommand(this);
            blockCommand = new BlockCommand(this);
            addCommand = new AddCommand(this);
            deleteCommand = new DeleteCommand(this);
            sortUsersCommand = new SortListCommand(this);
            getUsersCommand = new GetListCommand(this);
            logoutCommand = new LogOutCommand(this);
            showPersonInfoCommand = new InfoCommand(this);
            searchCommand = new SearchCommand(this);

            Users = personManager.GetUsers();
            this.personManager = personManager;
            listSorted = false;
        }

        public Action LogOut;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        //for addCommand & showPersonInfoCommand
        public void PersonInfo(bool cmdInfo = false) //cmdInfo - command to show person info
        {
            if (person == null && cmdInfo)
            {
                MessageBox.Show("You didn't choose the user!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                PersonInfoViewModel pvm = (person != null && cmdInfo) ?
                    new PersonInfoViewModel(personManager, Person) :
                    new PersonInfoViewModel(personManager);
                PersonInfo pI = new PersonInfo(pvm);
                var temp = pI.ShowDialog() ?? false;
                if (temp)
                {
                    Users = personManager.GetUsers();
                }
            }
        }

        public void Activate()
        {
            if (person != null && person.RoleId == (int)Roles.User)
            {
                person.Status = true;
                UpdateStatus();
            }
        }

        public void Block()
        {
            if (person != null && person.RoleId == (int)Roles.User)
            {
                person.Status = false;
                UpdateStatus();
            }
        }

        public void UpdateStatus()
        {
            personManager.UpdateUserStatus(person);
            Users = personManager.GetUsers();
        }

        public void GetUsers()
        {
            listSorted = false;
            Users = personManager.GetUsers();
        }

        public void GetSortedUsers()
        {
            listSorted = true;
            Users = personManager.GetSortedUsersByName();
        }

        public void Delete()
        {
            if (person != null)
            {
                personManager.DeletePerson(Person);
                Users = personManager.GetUsers();
            }
        }

        public void Search()
        {
            if (!String.IsNullOrEmpty(SearchPerson))
            {
                var users = new List<PersonDTO>();
                if (!String.IsNullOrEmpty(searchPerson))
                {
                    users = personManager.FindUsers(searchPerson);
                }
                if (users.Count != 0)
                {
                    Users = users;
                }
                else
                {
                    MessageBox.Show("No user", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    Users = personManager.GetUsers();
                }
            }
            else
            {
                Users = personManager.GetUsers();
            }
        }

    }
}

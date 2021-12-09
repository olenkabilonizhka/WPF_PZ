using AutoMapper;
using BLL;
using DTO;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace AdminWPF
{
    public class PersonInfoViewModel : INotifyPropertyChanged
    {
        IPersonManager personManager;
        PersonValid personV;
        public PersonValid PersonV
        {
            get
            {
                return personV;
            }
            set
            {
                personV = value;
                OnPropertyChanged(nameof(PersonV));
            }
        }
        public ICommand saveCommand { get; set; }
        public ICommand closeCommand { get; set; }
        static IMapper mapper;
        bool cmdInfo;

        public PersonInfoViewModel(IPersonManager personManager, PersonDTO person = null)
        {
            mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PersonProfile());
            }).CreateMapper();

            cmdInfo = (person != null) ? true : false;
            this.personManager = personManager;
            this.personV = (person != null) ? mapper.Map<PersonValid>(person) : new PersonValid();

            saveCommand = new SaveCommand(this);
            closeCommand = new CloseCommand(this);
        }

        public Action Saved;
        public Action Closed;

        public bool isValid()
        {
            return personV.isValid();
        }
        
        public void Save()
        {
            personV.RoleId = (int)Roles.User;
            var p = mapper.Map<PersonDTO>(personV);
            if (cmdInfo)
                personManager.UpdatePersonInfo(p,(personV.Password.Equals("********")) ? false : true);
            else
                personManager.CreatePerson(p);
        }

        public bool Close()
        {
            var res = MessageBox.Show("Close window?","",MessageBoxButton.OKCancel,MessageBoxImage.Question);
            return (res == MessageBoxResult.OK) ? true : false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}

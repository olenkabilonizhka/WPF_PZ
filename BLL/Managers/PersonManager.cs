using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonDAL personDAL;

        public PersonManager(IPersonDAL personDAL)
        {
            this.personDAL = personDAL;
        }

        public PersonDTO CreatePerson(PersonDTO person)
        {
            return personDAL.CreatePerson(person);
        }

        public void DeletePerson(PersonDTO person)
        {
            personDAL.Delete(person);
        }

        public void UpdatePersonInfo(PersonDTO person,bool passwordChanged)
        {
            var roleChanged = personDAL.GetAll().Find(x => x.PersonId == person.PersonId).RoleId == person.RoleId ? false : true;
            personDAL.UpdatePersonInfo(person,roleChanged,passwordChanged);
        }

        public void UpdateUserStatus(PersonDTO person)
        {
            personDAL.UpdateStatus(person);
        }

        public List<PersonDTO> GetSortedUsersByName()
        {
            return personDAL.GetAll().FindAll(x => x.RoleId == (int)Roles.User).OrderBy(x => x.Firstname).ToList();
        }

        public PersonDTO GetUserById(int personId)
        {
            return personDAL.GetAll().FindAll(x => x.RoleId == (int)Roles.User).SingleOrDefault(x => x.PersonId == personId);
        }

        public PersonDTO GetUserByEmail(string email)
        {
            return personDAL.GetAll().FindAll(x => x.RoleId == (int)Roles.User).SingleOrDefault(x => x.Email == email);
        }

        public PersonDTO GetUserByFullName(string name)
        {
            if (name.Split().Length > 1)
                return personDAL.GetAll().FindAll(x => x.RoleId == (int)Roles.User)
                    .SingleOrDefault(x => (name.Any(Char.IsWhiteSpace) && x.Firstname == name.Split()[0] && x.Lastname == name.Split()[1]));
            else
                return null;
        }

        public List<PersonDTO> GetUsers()
        {
            return personDAL.GetAll().FindAll(x => x.RoleId == (int)Roles.User);
        }

        public List<PersonDTO> GetAll()
        {
            return personDAL.GetAll();
        }

        public List<PersonDTO> FindUsers(string search)
        {
            int n = 0;
            Int32.TryParse(search,out n);
            return GetUsers()
                .FindAll(x => x.Firstname.Contains(search)
                || x.Lastname.Contains(search)
                || x.PersonId == n
                || x.Email.Contains(search));
        }
    }
}

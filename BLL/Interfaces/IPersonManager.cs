using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPersonManager
    {
        PersonDTO CreatePerson(PersonDTO person); 
        List<PersonDTO> GetUsers();
        List<PersonDTO> GetAll();
        List<PersonDTO> GetSortedUsersByName();
        PersonDTO GetUserById(int personId);
        PersonDTO GetUserByEmail(string email);
        PersonDTO GetUserByFullName(string name);
        void UpdatePersonInfo(PersonDTO person,bool passwordChanged);
        void UpdateUserStatus(PersonDTO person);
        void DeletePerson(PersonDTO person);
        List<PersonDTO> FindUsers(string search);
    }
}

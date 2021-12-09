using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IPersonDAL
    {
        PersonDTO CreatePerson(PersonDTO person);
        bool Login(string email, string password);
        List<PersonDTO> GetAll();
        void UpdatePersonInfo(PersonDTO person, bool roleChanged,bool passwordChanged);
        void UpdateStatus(PersonDTO person);
        void Delete(PersonDTO person);
    }
}

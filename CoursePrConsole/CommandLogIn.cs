using DAL;

namespace CoursePrConsole
{
    public class CommandLogIn
    {
        PersonDAL personDal;

        public CommandLogIn(string connStr)
        {
            personDal = new PersonDAL(connStr);
        }

        public bool LogInPerson(string email, string password)
        {
            return personDal.Login(email, password);
            //return personDal.GetAll().Exists(x => x.RoleId == (int)Roles.Admin && x.Email == email && x.Password.ToString() == password);
        }
    }
}

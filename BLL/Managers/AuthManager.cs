using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AuthManager : IAuthManager
    {
        private IPersonDAL personDAL;
        public AuthManager(IPersonDAL personDAL)
        {
            this.personDAL = personDAL;
        }

        public bool Login(string email, string password)
        {
            return personDAL.Login(email,password);
        }
    }
}

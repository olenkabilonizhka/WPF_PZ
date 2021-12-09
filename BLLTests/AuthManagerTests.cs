using BLL;
using DAL;
using DTO;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BLLTests
{
    [TestFixture]
    public class AuthManagerTests
    {
        protected TransactionScope transactionScope;
        Mock<IPersonDAL> personDAL;
        AuthManager manager;
        List<PersonDTO> people;

        [SetUp]
        public void SetUp()
        {
            transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);

            personDAL = new Mock<IPersonDAL>(MockBehavior.Strict);

            manager = new AuthManager(personDAL.Object);

            CreateUsers();
        }

        private void CreateUsers()
        {
            var user1 = new PersonDTO
            {
                PersonId = 1,
                Firstname = "Liam",
                Lastname = "Kaur",
                Email = "liam.kaur@gmail.com",
                Password = Encoding.UTF8.GetBytes("user1"),
                Salt = new Guid(),
                RoleId = (int)Roles.User,
                Status = true
            };
            var user2 = new PersonDTO
            {
                PersonId = 2,
                Firstname = "Maggie",
                Lastname = "Mulder",
                Email = "maggie.mulder@gmail.com",
                Password = Encoding.UTF8.GetBytes("admin1"),
                Salt = new Guid(),
                RoleId = (int)Roles.Admin
            };

            people = new List<PersonDTO> { user1, user2 };
        }

        [Test]
        public void LoginTest()
        {
            PersonDTO inPerson = people.First();
            bool resOut = false;
            personDAL.Setup(x => x.Login("liam.kaur@gmail.com", "user1")).Returns(resOut);

            var res = manager.Login("liam.kaur@gmail.com", "user1");

            Assert.AreEqual(res, resOut);
        }

        [Test]
        public void LoginTest2()
        {
            PersonDTO inPerson = people.Last();
            bool resOut = true;
            personDAL.Setup(x => x.Login("maggie.mulder@gmail.com", "admin1")).Returns(resOut);

            var res = manager.Login("maggie.mulder@gmail.com", "admin1");

            Assert.AreEqual(res, resOut);
        }

    }
}

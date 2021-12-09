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
    public class PersonManagerTests
    {
        protected TransactionScope transactionScope;
        Mock<IPersonDAL> personDAL;
        PersonManager manager;
        List<PersonDTO> people;

        [SetUp]
        public void SetUp()
        {
            transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);

            personDAL = new Mock<IPersonDAL>(MockBehavior.Strict);

            manager = new PersonManager(personDAL.Object);

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
            var user2  = new PersonDTO
            {
                PersonId = 2,
                Firstname = "Maggie",
                Lastname = "Mulder",
                Email = "maggie.mulder@gmail.com",
                Password = Encoding.UTF8.GetBytes("admin1"),
                Salt = new Guid(),
                RoleId = (int)Roles.Admin
            };
            var user3 = new PersonDTO
            {
                PersonId = 3,
                Firstname = "Andrew",
                Lastname = "Sheppard",
                Email = "andrew.sheppard@gmail.com",
                Password = Encoding.UTF8.GetBytes("user2"),
                Salt = new Guid(),
                RoleId = (int)Roles.User,
                Status = true
            };

            people = new List<PersonDTO> { user1, user2, user3 };
        }

        [Test]
        public void CreatePersonTest()
        {
            PersonDTO inPerson = new PersonDTO
            {
                Firstname = "Julia",
                Lastname = "Roberts",
                Email = "julia.roberts@gmail.com",
                Password = Encoding.UTF8.GetBytes("user"),
                RoleId = (int)Roles.User,
                Status = true
            };
            PersonDTO outPerson = new PersonDTO { PersonId = 1 };
            personDAL.Setup(x => x.CreatePerson(inPerson)).Returns(outPerson);

            var res = manager.CreatePerson(inPerson);

            Assert.IsNotNull(res);
            Assert.AreEqual(outPerson.PersonId, res.PersonId);
        }

        [Test]
        public void GetAllTest()
        {
            List<PersonDTO> listIn = new List<PersonDTO>(people);
            
            personDAL.Setup(x => x.GetAll()).Returns(listIn);

            var res = manager.GetAll();

            Assert.IsNotEmpty(res);
            Assert.AreEqual(res,listIn);
        }

        [Test]
        public void GetUsersTest()
        {
            List<PersonDTO> listIn = new List<PersonDTO>(people);

            List<PersonDTO> listOut = new List<PersonDTO> { people.First(), people.Last() };

            personDAL.Setup(x => x.GetAll()).Returns(listIn);

            var res = manager.GetUsers();

            Assert.AreEqual(res, listOut);
        }

        [Test]
        public void GetSortedUsersByNameTest()
        {
            List<PersonDTO> listIn = new List<PersonDTO>(people);

            List<PersonDTO> listOut = new List<PersonDTO> { people.Last(), people.First() };

            personDAL.Setup(x => x.GetAll()).Returns(listIn);

            var res = manager.GetSortedUsersByName();

            Assert.AreEqual(res, listOut);
        }

        [Test]
        public void GetUserByIdTest()
        {
            int personIdIn = 1;

            PersonDTO personOut = people.First();

            personDAL.Setup(x => x.GetAll()).Returns(people);

            var res = manager.GetUserById(personIdIn);

            Assert.IsNotNull(res);
            Assert.AreEqual(res, personOut);
        }

        [Test]
        public void GetUserByIdTest2()
        {
            int personIdIn = 5;

            personDAL.Setup(x => x.GetAll()).Returns(people);

            var res = manager.GetUserById(personIdIn);

            Assert.IsNull(res);
        }

        [Test]
        public void GetUserByEmailTest()
        {
            string personEmailIn = "maggie.mulder@gmail.com";

            personDAL.Setup(x => x.GetAll()).Returns(people);

            var res = manager.GetUserByEmail(personEmailIn);

            Assert.IsNull(res);
        }

        [Test]
        public void GetUserByEmailTest2()
        {
            string personEmailIn = "andrew.sheppard@gmail.com";

            PersonDTO personOut = people[2];

            personDAL.Setup(x => x.GetAll()).Returns(people);

            var res = manager.GetUserByEmail(personEmailIn);

            Assert.IsNotNull(res);
            Assert.AreEqual(res, personOut);
        }

        [Test]
        public void GetUserByNameOrFullNameTest()
        {
            string personIn = "Ann";

            personDAL.Setup(x => x.GetAll()).Returns(people);

            var res = manager.GetUserByFullName(personIn);

            Assert.IsNull(res);
        }

        [Test]
        public void GetUserByNameOrFullNameTest2()
        {
            string personIn = "Andrew Sheppard";

            PersonDTO personOut = people[2];

            personDAL.Setup(x => x.GetAll()).Returns(people);

            var res = manager.GetUserByFullName(personIn);

            Assert.AreEqual(res, personOut);
        }

        [Test]
        public void UpdatePersonInfoTest()
        {
            PersonDTO personIn = new PersonDTO
            {
                PersonId = 7,
                Firstname = "Sam",
                Lastname = "Kylie",
                Email = "sam.kylie@gmail.com",
                Password = Encoding.UTF8.GetBytes("userNew"),
                Salt = new Guid(),
                RoleId = (int)Roles.User,
                Status = false
            };
            bool passwordChanged = true;
            bool roleChanged = false;
             
            personDAL.Setup(x => x.UpdatePersonInfo(personIn,roleChanged,passwordChanged));
            personDAL.Setup(x => x.GetAll()).Returns(people);
            try
            {
                manager.UpdatePersonInfo(personIn, passwordChanged);
                Assert.IsTrue(false);
            }
            catch(Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void UpdatePersonInfoTest2()
        {
            PersonDTO personIn = new PersonDTO
            {
                PersonId = 1,
                Firstname = "Sam",
                Lastname = "Kylie",
                Email = "sam.kylie@gmail.com",
                Password = Encoding.UTF8.GetBytes("userNew"),
                Salt = new Guid(),
                RoleId = (int)Roles.User,
                Status = false
            };
            bool passwordChanged = true;
            bool roleChanged = false;

            personDAL.Setup(x => x.UpdatePersonInfo(personIn, roleChanged, passwordChanged));
            personDAL.Setup(x => x.GetAll()).Returns(people);
            try
            {
                manager.UpdatePersonInfo(personIn, passwordChanged);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [Test]
        public void UpdateStatusTest()
        {
            PersonDTO person = people.First();
            person.Status = false;

            personDAL.Setup(x => x.UpdateStatus(person));

            try
            {
                manager.UpdateUserStatus(person);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

        [Test]
        public void DeleteTest()
        {
            PersonDTO person = people.First();

            personDAL.Setup(x => x.Delete(person));

            try
            {
                manager.DeletePerson(person);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }

    }
}

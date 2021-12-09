using DTO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace DAL
{
    public class PersonDAL : IPersonDAL
    {
        protected string connStr;

        public PersonDAL(string connStr)
        {
            this.connStr = connStr;
        }

        public PersonDTO CreatePerson(PersonDTO person)
        {
            var personFind = GetAll().SingleOrDefault(x => x.Email == person.Email);

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();

                if(personFind != null)
                {
                    throw new Exception("Already exists!");
                }

                person.Salt = Guid.NewGuid();

                comm.CommandText = "INSERT INTO Person(Firstname,Lastname,Email,Password,Salt,RoleId) output INSERTED.PersonId VALUES(@firstname,@lastname,@email,@password,@salt,@roleid)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@firstname", person.Firstname);
                comm.Parameters.AddWithValue("@lastname", person.Lastname);
                comm.Parameters.AddWithValue("@email", person.Email);
                comm.Parameters.AddWithValue("@password", hash(Encoding.UTF8.GetString(person.Password),person.Salt.ToString()));
                comm.Parameters.AddWithValue("@salt", person.Salt);
                comm.Parameters.AddWithValue("@roleid", person.RoleId);
                person.PersonId = (int)comm.ExecuteScalar();

                if ((int)Roles.User == person.RoleId)
                {
                    comm.CommandText = "INSERT INTO [User](PersonId,Status) VALUES(@personid,@status)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@personid", person.PersonId);
                    comm.Parameters.AddWithValue("@status", 1);
                    comm.ExecuteNonQuery();
                }
            }

            return person;
        }

        private byte[] hash(string password, string salt)
        {
            var pass = SHA512.Create();
            return pass.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }

        public void Delete(PersonDTO person)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                if ((int)Roles.User == person.RoleId)
                {
                    comm.CommandText = $"DELETE FROM [User] WHERE PersonId={person.PersonId}";
                    comm.ExecuteNonQuery();
                }
                comm.CommandText = $"DELETE FROM Person WHERE PersonId={person.PersonId}";
                comm.ExecuteNonQuery();
            }
        }

        public void UpdatePersonInfo(PersonDTO person,bool roleChanged = false, bool passwordChanged = false)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                if (roleChanged)
                {
                    if (person.RoleId == (int)Roles.User)
                    {
                        comm.CommandText = "INSERT INTO [User](PersonId,Status) VALUES(@personid,@status)";
                        comm.Parameters.Clear();
                        comm.Parameters.AddWithValue("@personid", person.PersonId);
                        comm.Parameters.AddWithValue("@status", 1);
                        comm.ExecuteNonQuery();
                    }
                    else if (person.RoleId == (int)Roles.Admin)
                    {
                        comm.CommandText = $"DELETE FROM [User] WHERE PersonId={person.PersonId}";
                        comm.ExecuteNonQuery();
                    }
                    else
                        throw new Exception($"Not exist RoleId={person.RoleId}.");
                }

                comm.CommandText = $"UPDATE Person SET Firstname = @firstname, Lastname = @lastname, Email = @email, Password = @password, RoleId = @roleid, RowUpdateTime = @rowupdatetime WHERE PersonId={person.PersonId}";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@firstname", person.Firstname);
                comm.Parameters.AddWithValue("@lastname", person.Lastname);
                comm.Parameters.AddWithValue("@email", person.Email);
                comm.Parameters.AddWithValue("@password", passwordChanged ? hash(Encoding.UTF8.GetString(person.Password), person.Salt.ToString()) : person.Password);
                comm.Parameters.AddWithValue("@roleid", person.RoleId);
                comm.Parameters.AddWithValue("@rowupdatetime", DateTime.Now);
                comm.ExecuteNonQuery();
            }
        }

        public List<PersonDTO> GetAll()
        {
            var people = new List<PersonDTO>();
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                comm.CommandText = "SELECT p.PersonId,p.Firstname,p.Lastname,p.Email,p.Password,p.Salt,r.RoleId,r.RoleName," +
                    "c.Status,p.RowInsertTime,p.RowUpdateTime,c.RowInsertTime as RowInsertTimeStatus,c.RowUpdateTime as RowUpdateTimeStatus " +
                    "FROM Person p JOIN [Role] r ON p.RoleId=r.RoleId " +
                    "LEFT OUTER JOIN [User] c ON p.PersonId=c.PersonId";
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    var t = (int)Roles.User == (int)reader["RoleId"];
                    people.Add(new PersonDTO
                    {
                        PersonId = (int)reader["PersonId"],
                        Firstname = reader["Firstname"].ToString(),
                        Lastname = reader["Lastname"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = (byte[])reader["Password"],
                        Salt = (Guid)reader["Salt"], 
                        RoleId = (int)reader["RoleId"], 
                        RoleName = reader["RoleName"].ToString(),
                        Status = (int)Roles.User == (int)reader["RoleId"] ? (bool)reader["Status"] : (bool?)null,
                        RowInsertTime = (DateTime)reader["RowInsertTime"],
                        RowUpdateTime = (DateTime)reader["RowUpdateTime"],
                        RowInsertTimeStatus = (int)Roles.User == (int)reader["RoleId"] ? (DateTime)reader["RowInsertTimeStatus"] : (DateTime?)null,
                        RowUpdateTimeStatus = (int)Roles.User == (int)reader["RoleId"] ? (DateTime)reader["RowUpdateTimeStatus"] : (DateTime?)null
                    });
                }
            }

            return people;
        }

        public void UpdateStatus(PersonDTO person)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();

                if (person.RoleId == (int)Roles.User)
                {
                    comm.CommandText = $"UPDATE [User] SET Status = @status, RowUpdateTime = @rowupdatetime WHERE PersonId={person.PersonId}";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@status", (bool)person.Status ? 1 : 0);
                    comm.Parameters.AddWithValue("@rowupdatetime", DateTime.Now);
                    comm.ExecuteNonQuery();
                }
                else if (person.RoleId == (int)Roles.Admin)
                    throw new Exception($"Admin does not have a status.");
                else
                    throw new Exception($"Not exist RoleId={person.RoleId}.");
            }
        }

        public bool Login(string email, string password)
        {
            var person = GetAll().SingleOrDefault(x => x.Email == email);
            return person != null && person.Password.SequenceEqual(hash(password, person.Salt.ToString()));
        }
    }
}

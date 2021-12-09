using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public Guid Salt { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? Status { get; set; }

        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public DateTime? RowInsertTimeStatus { get; set; }
        public DateTime? RowUpdateTimeStatus { get; set; }

        public bool isEmpty()
        {
            return this.PersonId == 0 && Firstname == null && Lastname == null && Email == null && Password == null && RoleId == 0;
        }
    }
}

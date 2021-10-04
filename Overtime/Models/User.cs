using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public enum Gender
        {
            Male,
            Female
        }
        public Gender GenderName { get; set; }
        public string PhoneNumber { get; set; }
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<UserRequest> UserRequests { get; set; }
        public virtual Account Account { get; set; }
    }
}

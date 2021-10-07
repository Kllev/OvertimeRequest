using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Models
{
    public class User
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string Email { get; set; }
        public enum Gender
        {
            Male,
            Female
        }
        [Required]
        public Gender GenderName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int DivisionId { get; set; }
        [Required]
        public virtual Division Division { get; set; }
        public virtual ICollection<UserRequest> UserRequests { get; set; }
        public virtual Account Account { get; set; }
    }
}

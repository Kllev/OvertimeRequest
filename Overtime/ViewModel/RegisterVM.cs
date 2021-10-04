using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.ViewModel
{
    public class RegisterVM
    {
        [Required]
        public string userID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        public enum Gender 
        { 
            Male,
            Female
        }
        [Required]
        public Gender gender { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{6,20}$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        //[StringLength(32, ErrorMessage = "Must be between 5 and 32 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public int DivisionID { get; set; }
    }
}

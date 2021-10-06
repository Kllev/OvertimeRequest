using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.ViewModel
{
    public class LoginVM
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Id { get; set; }
        public string NewPassword { get; set; }
    }
}

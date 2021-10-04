using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
        public virtual User User { get; set; }
    }
}

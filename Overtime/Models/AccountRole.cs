using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Models
{
    public class AccountRole
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int RoleId { get; set; }
        public virtual Account Account { get; set; }
        public virtual Role Role { get; set; }
    }
}

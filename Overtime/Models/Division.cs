using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Models
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

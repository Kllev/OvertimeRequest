using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Models
{
    public class UserRequest
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string UserId { get; set; }
        public string JobTask { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public virtual User User { get; set; }
        public virtual Request Request { get; set; }
    }
}

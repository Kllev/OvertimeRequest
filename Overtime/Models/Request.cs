using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Models
{
    public class Request
    {
        public int Id { get; set; }
        public enum Status
        {
            Accepted,
            Decline
        }
        public Status StatusName { get; set; }
        public DateTime RequuestDate { get; set; }
        public string ApproverName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalaryOvertime { get; set; }
        public virtual ICollection<UserRequest> UserRequests { get; set; }
    }
}

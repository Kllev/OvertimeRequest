using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Models
{
    public class Request
    {
        public Request()
        {
        }

        public int Id { get; set; }
        public enum Status
        {
            Accepted,
            Decline,
            Proccess,
            Proccessed
        }
        public Status? StatusName { get; set; }
        public DateTime RequestDate { get; set; }
        public string ApproverName { get; set; }
        //[Column(TypeName = "double(18,2)")]
        public double SalaryOvertime { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRequest> UserRequests { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.ViewModel
{
    public class GetReqRequesterVM
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public enum Status
        {
            Accepted,
            Decline,
            Proccess
        }
        public Status StatusName { get; set; }
        public DateTime RequestDate { get; set; }
        public string ApproverName { get; set; }
        //[Column(TypeName = "double(18,2)")]
        public double SalaryOvertime { get; set; }
    }
}

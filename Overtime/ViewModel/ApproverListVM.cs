using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.ViewModel
{
    public class ApproverListVM
    {
        public int Id { get; set; }
        public enum Status
        {
            Accepted,
            Decline,
            Proccess,
            Proccessed
        }
        public Status StatusName { get; set; }
        public DateTime RequestDate { get; set; }
        public string ApproverName { get; set; }
        //[Column(TypeName = "double(18,2)")]
        public double SalaryOvertime { get; set; }
    }
}

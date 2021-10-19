using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.ViewModel
{
    public class ListGetReqByManagerVM
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeId { get; set; }
        public enum Status
        {
            Accepted,
            Decline,
            Proccess,
            Proccessed
        }
        public Status StatusName { get; set; }
        public DateTime RequestDate { get; set; }
        public int SalaryOvertime { get; set; }
    }
}

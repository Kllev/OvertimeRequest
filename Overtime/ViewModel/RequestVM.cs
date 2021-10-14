using Overtime.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.ViewModel
{
    public class RequestVM
    {
        //public string UserID { get; set; }
        public int Salary { get; set; }
        //[Required(ErrorMessage = "Jobtask is required")]
        //public string JobTask { get; set; }
        ////[Required(ErrorMessage = "Description is required")]
        //public string Desc { get; set; }
        //[Required(ErrorMessage = "Date Request is required")]
        //public DateTime Date { get; set; }
        public DateTime RequestDate { get; set; }
        //[Required(ErrorMessage = "Time Start is required")]
        //public DateTime StartTime { get; set; }
        //[Required(ErrorMessage = "Time End is required")]
        //public DateTime EndTime { get; set; }
        public enum status
        {
            Accepted,
            Decline,
            Proccess
        }
        public status StatusName { get; set; }
        public string ApproverName { get; set; }
        //[Column(TypeName = "decimal(18,2)")]
        //public decimal SalaryOvertime { get; set; }
        public List<UserRequest> userRequests { get; set; }
        public int Time { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.ViewModel
{
    public class UserReqVM
    {
        [Required]
        public int RequestId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string JobTask { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int EndTime { get; set; }
        [Required]
        public int StartTime { get; set; }
        public int Time { get; set; }
    }
}

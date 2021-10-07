using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Overtime.Models
{
    public class UserRequest
    {
        public int Id { get; set; }
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
        public DateTime EndTime { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public virtual User User { get; set; }
        [Required]
        public virtual Request Request { get; set; }
    }
}

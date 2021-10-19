using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
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
            Proccess,
            Proccessed
        }
        [Range(0, 3)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status ? StatusName { get; set; }
        public DateTime RequestDate { get; set; }
        public string ApproverName { get; set; }
        //[Column(TypeName = "double(18,2)")]
        public double SalaryOvertime { get; set; }
    }
}

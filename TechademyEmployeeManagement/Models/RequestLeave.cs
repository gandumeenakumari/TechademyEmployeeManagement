using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechademyEmployeeManagement.Models
{
    public class RequestLeave
    {
        [Key]
        public int ID { get; set; }
       
        //public EmployeeDetails EmployeeDetails { get; set; }
        public string LeaveType { get; set; }
        public DateTime When { get; set; }
        
        public string LeaveReason { get; set; }

    }
}

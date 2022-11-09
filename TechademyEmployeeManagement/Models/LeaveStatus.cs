using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechademyEmployeeManagement.Models
{
    public class LeaveStatus
    {
        [Key]
       
        public int ID { get; set; }
        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechademyEmployeeManagement.Models
{
    public class WorkingHours
    {
        public int ID { get; set; }
        //public string EmployeeID { get; set; }
        //public EmployeeDetails EmployeeDetails { get; set; }
        public TimeSpan CompanyWokingHours { get; set; }
        
        public TimeSpan EmployeeWorkingHours { get; set; }
        public TimeSpan TotalWorkingHours { get; set; }

    }
}

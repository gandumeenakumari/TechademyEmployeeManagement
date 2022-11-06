using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechademyEmployeeManagement.Models
{
    public class WorkingHours
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        
        public double CompanyWokingHours { get; set; }
        
        public double EmployeeWorkingHours { get; set; }
        //public double TotalWorkingHours { get { return TotalWorkingHours; } set { TotalWorkingHours = CompanyWokingHours + EmployeeWorkingHours; } }

    }
}

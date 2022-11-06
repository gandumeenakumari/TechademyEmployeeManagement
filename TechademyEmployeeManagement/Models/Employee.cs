using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechademyEmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public DateTime DOJ { get; set; }
        public string? Password { get; set; }
    }
}

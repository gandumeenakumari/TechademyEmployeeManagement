using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechademyEmployeeManagement.Models
{
    public class Designation
    {
        //public int DesigID { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }
        //public int ID { get; set; }
        public ICollection<EmployeeDetails> EmployeeDetails { get; set; }

    }
}
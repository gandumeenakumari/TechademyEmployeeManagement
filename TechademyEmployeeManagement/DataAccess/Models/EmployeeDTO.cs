﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechademyEmployeeManagement.DataAccess.Models
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime MemberSince { get; set; }
    }
}

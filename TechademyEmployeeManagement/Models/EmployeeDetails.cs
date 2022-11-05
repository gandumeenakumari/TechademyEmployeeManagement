﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechademyEmployeeManagement.Models
{
    public class EmployeeDetails
    {
        public int ID { get; set; }
        public string EmployeeID { get; set; }
        //public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
       
        public int DesignationID { get; set; }
        public Designation Designation { get; set; }
       
        public DateTime MemberSince { get; set; }

        //public ICollection<WorkingHours> WorkingHours { get; set; }
        //public ICollection<RequestLeave> RequestLeaves { get; set; }

    }
}

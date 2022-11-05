using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Core.IRepository
{
    public interface IEmployeeRepository
    {
        public Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees();
        public Task<ActionResult> AddNewEmployee(EmployeeDetails employee);
    }
}

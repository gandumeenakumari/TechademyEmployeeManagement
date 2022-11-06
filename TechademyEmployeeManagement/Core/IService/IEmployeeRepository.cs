using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Core.IService
{
    public interface IEmployeeRepository
    {
        //public  Task<IActionResult> GetAllEmployees();
         public Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees();
        public Task<IActionResult> AddNewEmployee([FromBody] EmployeeDetails employee);
    }
}

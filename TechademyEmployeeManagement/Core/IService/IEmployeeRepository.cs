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
        public Task<List<EmployeeDTO>> GetAllEmployees();
        public Task<EmployeeDTO> GetEmployee(int EmployeeID);
        public Task<EmployeeDetails> GetEmployeeByID(int EmployeeID);

         //public Task<IActionResult> AddNewEmployee([FromBody] EmployeeDetails employee);
        //public Task<ActionResult<EmployeeDetails>> AddNewEmployee(EmployeeDetails employee);
        public Task<EmployeeDetails> AddNewEmployee(EmployeeDetails employee);
        public Task<EmployeeDetails> UpdateEmployee(int EmployeeID, EmployeeDetails employeeDetails);
        public Task<EmployeeDetails> DeleteEmployee(int EmployeeID);

        void Save();
        Task SaveChangesAsync();
    }
}

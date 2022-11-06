using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Core.IService;
using TechademyEmployeeManagement.Core.Service;
using TechademyEmployeeManagement.Data;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {

        private readonly IEmployeeRepository employeeRepository;
        
        public EmployeeDetailsController(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
            

        }

        [HttpGet]


        public Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
        //public Task<IActionResult> GetAllEmployees();
        {

                var employee = employeeRepository.GetAllEmployees();
                return employee;
  
           
        }

        [HttpPost]

        public async Task<IActionResult> AddNewEmployee([FromBody] EmployeeDetails employee)
        {
            return Ok(employee);
        }













        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<EmployeeDetails>>> GetAllEmployeeDetails()
        //{
        //    return await _context.EmployeeDetails
        //        .AsNoTracking()
        //        .Include(i=>i.Designation)
        //        .ToListAsync();

        //}
        //[HttpPost]
        //public async Task<ActionResult> AddNewEmployee(EmployeeDetails employee)
        //{
        //    _context.EmployeeDetails.Add(employee);
        //    // await _context.EmployeeDetails.AddAsync(employee);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetAllEmployeeDetails",
        //    new { id = employee.ID }, employee);
    }

    }


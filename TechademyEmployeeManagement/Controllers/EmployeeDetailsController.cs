using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Core.IRepository;
using TechademyEmployeeManagement.Core.Repository;
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

        public ActionResult<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            try
            {
                var employee = employeeRepository.GetAllEmployees();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]

        public ActionResult AddNewEmployee(EmployeeDetails employee)
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


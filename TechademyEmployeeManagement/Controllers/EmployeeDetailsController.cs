using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.DataAccess;
using TechademyEmployeeManagement.DataAccess.Models;

namespace TechademyEmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly EmployeeContext _context;
        public EmployeeDetailsController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
        {
            var employee = await _context.EmployeeDetails
                .Join(
                _context.Designation,
                emp => emp.DesignationID,
                des => des.DesignationID,
                (emp, des) => new EmployeeDTO
                {
                    ID = emp.ID,
                    EmployeeName = emp.EmployeeName,
                    Gender = emp.Gender,
                    MobileNumber = emp.MobileNumber,
                    Address = emp.Address,
                    Email = emp.Email,
                    DesignationID = des.DesignationID,
                    DesignationName = des.DesignationName,
                    MemberSince = emp.MemberSince

                }
                ).ToListAsync();
            return employee;
        }

        [HttpPost]

        public async Task<ActionResult> AddNewEmployee(EmployeeDetails employee)
        {
            _context.EmployeeDetails.Add(employee);
            // await _context.EmployeeDetails.AddAsync(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAllEmployees", new { id = employee.ID }, employee);

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


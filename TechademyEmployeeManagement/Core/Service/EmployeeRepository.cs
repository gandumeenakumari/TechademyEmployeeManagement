using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Core.IService;
using TechademyEmployeeManagement.Data;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Core.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;


        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;

        }

        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            
            var employee = await _context.EmployeeDetails
                 .Join(
                 _context.Designation,
                 emp => emp.DesignationID,
                 des => des.DesignationID,
                 (emp, des) => new EmployeeDTO
                 {
                     ID = emp.ID,
                     EmployeeID = emp.EmployeeID,
                     EmployeeName = emp.EmployeeName,
                     Gender = emp.Gender,
                     MobileNumber = emp.MobileNumber,
                     Address = emp.Address,
                     Email = emp.Email,
                     DesignationID = des.DesignationID,
                     DesignationName = des.DesignationName,
                     RoleName = des.RoleName,
                     DepartmentName = des.DepartmentName,
                     MemberSince = emp.MemberSince

                 }
                 ).ToListAsync();
            await _context.SaveChangesAsync();

            return employee;
            //return await _context.EmployeeDetails.ToListAsync();
        }

        public async Task<EmployeeDetails> AddNewEmployee(EmployeeDetails employee)
        {
            var result = await _context.EmployeeDetails.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        //public Task<ActionResult<IEnumerable<EmployeeDetails>>> GetAllEmployees()
        //{
        //  var employee = _context.EmployeeDetails.ToListAsync();
        //return employee;
        //}



        //public async Task<IActionResult> AddNewEmployee([FromBody] EmployeeDetails employee)
        //{
        //    await _context.EmployeeDetails.AddAsync(employee);
        //    await _context.SaveChangesAsync();
        //    return Ok(employee);

        //}


    }
}
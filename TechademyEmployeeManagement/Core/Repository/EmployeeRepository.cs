using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Core.IRepository;
using TechademyEmployeeManagement.Data;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Core.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
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
            return employee;
        }
        public async Task<ActionResult> AddNewEmployee(EmployeeDetails employee)
        {
            _context.EmployeeDetails.Add(employee);
            // await _context.EmployeeDetails.AddAsync(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAllEmployees", new { id = employee.ID }, employee);

        }

        private ActionResult CreatedAtAction(string v, object p, EmployeeDetails employee)
        {
            throw new NotImplementedException();
        }
    }
}
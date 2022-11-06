using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechademyEmployeeManagement
{
    public class backup
    {


//        using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using TechademyEmployeeManagement.Core.IService;
//using TechademyEmployeeManagement.Data;
//using TechademyEmployeeManagement.Models;

//namespace TechademyEmployeeManagement.Core.Service
//    {
//        public class EmployeeRepository : IEmployeeRepository
//        {
//            private readonly EmployeeContext _context;


//            public EmployeeRepository(EmployeeContext context)
//            {
//                _context = context;

//            }

//            public Task<IActionResult> AddNewEmployee([FromBody] EmployeeDetails employee)
//            {
//                throw new NotImplementedException();
//            }

//            public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
//            {
//                var db = new EmployeeContext();
//                var employee = await _context.EmployeeDetails
//                     .Join(
//                     _context.Designation,
//                     emp => emp.DesignationID,
//                     des => des.DesignationID,
//                     (emp, des) => new EmployeeDTO
//                     {
//                         ID = emp.ID,
//                         EmployeeID = emp.EmployeeID,
//                         EmployeeName = emp.EmployeeName,
//                         Gender = emp.Gender,
//                         MobileNumber = emp.MobileNumber,
//                         Address = emp.Address,
//                         Email = emp.Email,
//                         DesignationID = des.DesignationID,
//                         DesignationName = des.DesignationName,
//                         RoleName = des.RoleName,
//                         DepartmentName = des.DepartmentName,
//                         MemberSince = emp.MemberSince

//                     }
//                     ).ToListAsync();
//                await _context.SaveChangesAsync();

//                return employee;
//            }
//            //public Task<ActionResult<IEnumerable<EmployeeDetails>>> GetAllEmployees()
//            //{
//            //  var employee = _context.EmployeeDetails.ToListAsync();
//            //return employee;
//            //}



//            //public async Task<IActionResult> AddNewEmployee([FromBody] EmployeeDetails employee)
//            //{
//            //    await _context.EmployeeDetails.AddAsync(employee);
//            //    await _context.SaveChangesAsync();
//            //    return Ok(employee);

//            //}

//            private IActionResult Ok(EmployeeDetails employee)
//            {
//                throw new NotImplementedException();
//            }


        }
    }

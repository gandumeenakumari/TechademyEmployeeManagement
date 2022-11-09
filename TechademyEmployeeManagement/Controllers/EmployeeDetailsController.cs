using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public EmployeeDetailsController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;


        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()

        {
            try {
                return Ok(await employeeRepository.GetAllEmployees());
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
            //return await employeeRepository.GetAllEmployees();
          
        }

        //[HttpGet("{EmployeeID:int}")]
       
        //public async Task<ActionResult<EmployeeDTO>> GetEmployee(int EmployeeID)
        //{
        //    try
        //    {
        //        var result = await employeeRepository.GetEmployee(EmployeeID);
        //        if (result == null) return NotFound();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ex.Message);
        //    }
        //}


        [HttpPost]
        public async Task<ActionResult<EmployeeDetails>> AddNewEmployee(EmployeeDetails employee)
        {
        
                var create = await employeeRepository.AddNewEmployee(employee);
                return CreatedAtAction(nameof(GetAllEmployees), new { id = create.EmployeeID }, create);

        }
        [HttpPut]
        public async Task<ActionResult<EmployeeDetails>> UpdateEmployee(int EmployeeID, EmployeeDetails employeeDetails)
        {
            try
            {
                if (EmployeeID != EmployeeID)
                    return BadRequest("Employee ID mismatch");
                var update = await employeeRepository.GetEmployeeByID(EmployeeID);
                if (update == null)
                {
                    return NotFound("Employee ID not found");
                }

                return await employeeRepository.UpdateEmployee(EmployeeID, employeeDetails);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpGet("{EmployeeID:int}")]
       // [Route("Employee/EmployeeID")]
        public async Task<ActionResult<EmployeeDetails>> GetEmployeeByID(int EmployeeID)
        {
            try
            {
                var result = await employeeRepository.GetEmployeeByID(EmployeeID);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpDelete("{EmployeeID:int}")]
        public async Task<ActionResult> DeleteEmployee(int EmployeeID)
        {
            try
            {
                var del = await employeeRepository.GetEmployeeByID(EmployeeID);
                if(del==null)
                {
                    return NotFound($"Employee with EmployeeID={EmployeeID} not found");
                }
                var emp= await employeeRepository.DeleteEmployee(EmployeeID);
                return Ok(emp);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

    }
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

//((Microsoft.EntityFrameworkCore.Internal.InternalDbSet<TechademyEmployeeManagement.Models.EmployeeDetails>)((TechademyEmployeeManagement.Core.Service.EmployeeRepository)employeeRepository)._context.EmployeeDetails).Local = Function evaluation disabled because a previous function evaluation timed out. You must continue execution to reenable function evaluation.
//StackTrace = "   at Microsoft.EntityFrameworkCore.Internal.ConcurrencyDetector.EnterCriticalSection()\r\n   at Microsoft.EntityFrameworkCore.Query.Internal.QueryingEnumerable`1.Enumerator.MoveNext()\r\n   at System.Collections.Generic.LargeArrayBuilder`1.AddRange(IEnume...
// public async Task<IActionResult> AddNewEmployee([FromBody] EmployeeDetails employee) => Ok(employee);
// public Task<IActionResult> GetAllEmployees();
//public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
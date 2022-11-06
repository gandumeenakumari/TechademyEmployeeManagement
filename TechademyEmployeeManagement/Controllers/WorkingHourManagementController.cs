using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Core.IService;
using TechademyEmployeeManagement.Data;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHourManagementController : ControllerBase
    {
        private readonly IWorkingHourManagement workingHourManagement;

        public WorkingHourManagementController(IWorkingHourManagement workingHourManagement)
        {
            this.workingHourManagement = workingHourManagement;
        }
        [HttpGet]
        public async Task<ActionResult> GetTtoalWorkingHours()
        {
            try
            {
               
                return Ok(await workingHourManagement.GetTtoalWorkingHours());
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{ID:int}")]
         public  async Task<ActionResult<WorkingHours>> GetWorkingHour(int ID)
        {
            try
            {
                var result = await workingHourManagement.GetWorkingHour(ID);
                if (result == null) return NotFound();
                return result;
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<WorkingHours>> AddWorkingHours(WorkingHours workingHours)
        {
            try
            {
                var create = await workingHourManagement.AddWorkingHours(workingHours);
                return CreatedAtAction(nameof(GetTtoalWorkingHours), new { id = create.ID }, create);
            }
            
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<WorkingHours>> UpdateWorkingHours(int ID,WorkingHours workingHours)
        {
            try
            {
                if (ID!= workingHours.ID)
                    return BadRequest("Employee ID mismatch");
                var update = await workingHourManagement.GetWorkingHour(ID);
                if(update==null)
                {
                    return NotFound("Employee ID not found");
                }
                return await workingHourManagement.UpdateWorkingHours(ID,workingHours);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<WorkingHours>> DeleteWorkingHours(int ID)
        {
            try
            {
                var del = await workingHourManagement.GetWorkingHour(ID);
                if(del==null)
                {
                    return NotFound($"Employee with ID={ID} not found");
                }
                return null;
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

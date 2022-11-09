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
        public async Task<ActionResult> GetToalWorkingHours()
        {
            try
            {
               
                return Ok(await workingHourManagement.GetToalWorkingHours());
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
                return CreatedAtAction(nameof(GetToalWorkingHours), new { id = create.ID }, create);
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
                    return BadRequest("ID mismatch");
                var update = await workingHourManagement.GetWorkingHour(ID);
                if(update==null)
                {
                    return NotFound("ID not found");
                }
                return await workingHourManagement.UpdateWorkingHours(ID,workingHours);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpDelete("{ID:int}")]
        public async Task<ActionResult> DeleteWorkingHours(int ID)
        {
            try
            {
                var del = await workingHourManagement.GetWorkingHour(ID);
                if(del==null)
                {
                    return NotFound($"Employee with ID={ID} not found");
                }
                var hour = await workingHourManagement.DeleteWorkingHours(ID);
                return Ok(hour);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}

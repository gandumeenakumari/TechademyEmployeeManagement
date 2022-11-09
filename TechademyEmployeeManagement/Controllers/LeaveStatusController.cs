using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Core.IService;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveStatusController : ControllerBase
    {
        private readonly ILeaveStatusRepository leaveStatusRepository;
        public LeaveStatusController(ILeaveStatusRepository leaveStatusRepository)
        {
            this.leaveStatusRepository = leaveStatusRepository;
        }
        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
            return Ok(await leaveStatusRepository.GetAll());
        }
        [HttpGet("{ID:int}")]
        public async Task<ActionResult<LeaveStatus>> GetStatus(int ID)
        {
            try
            {
                var result = await leaveStatusRepository.GetStatus(ID);
                if (result == null) return NotFound();
                return result;

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<LeaveStatus>> AddStatus(LeaveStatus leaveStatus)
        {
            var create = await leaveStatusRepository.AddStatus(leaveStatus);
            return CreatedAtAction(nameof(GetAll), new { id = create.ID }, create);

        }

        [HttpPut]
        public async Task<ActionResult<LeaveStatus>> UpdateStatus(int ID, LeaveStatus leaveStatus)
        {
            try
            {
                if (ID != leaveStatus.ID)
                    return BadRequest("ID mismatch");
                var update = await leaveStatusRepository.GetStatus(ID);
                if (update == null)
                {
                    return NotFound("ID not Found");
                }
                return await leaveStatusRepository.UpdateStatus(ID, leaveStatus);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpDelete("{ID:int}")]
        public async Task<ActionResult> DeleteStatus(int ID)
        //public async Task<ActionResult<RequestLeave>> DeleteLeave(int LeaveID)
        {

            try
            {
                var result = await leaveStatusRepository.GetStatus(ID);

                if (result == null) return NotFound($"Employee with ID={ID} not found");
                var del = await leaveStatusRepository.DeleteStatus(ID);
                return Ok(del);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }


    }
}

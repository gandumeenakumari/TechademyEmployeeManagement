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
    public class RequestLeaveController : ControllerBase
    {
        private readonly IRequestLeaveRepository requestLeaveRepository;
        public RequestLeaveController(IRequestLeaveRepository requestLeaveRepository)
        {
            this.requestLeaveRepository = requestLeaveRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllLeaves()
        {
            return Ok(await requestLeaveRepository.GetAllLeaves());
        }
        [HttpPost]
        public async Task<ActionResult<RequestLeave>> AddLeave(RequestLeave requestLeave)
        {
            var create = await requestLeaveRepository.AddLeave(requestLeave);
            return CreatedAtAction(nameof(GetAllLeaves), new { id = create.ID }, create);
        
        }
            
            
           [HttpPut]
        public async Task<ActionResult<RequestLeave>> UpdateLeave(int ID, RequestLeave requestLeave)
        {
            try
            {
                if (ID != requestLeave.ID)
                    return BadRequest("ID mismatch");
                var update = await requestLeaveRepository.GetLeave(ID);
                if (update==null)
                {
                    return NotFound("ID not Found");
                }
                return await requestLeaveRepository.UpdateLeave(ID, requestLeave);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("{ID:int}")]
        public async Task<ActionResult<RequestLeave>> GetLeave(int ID)
        {
            try
            {
                var result = await requestLeaveRepository.GetLeave(ID);
                if (result == null) return NotFound();
                return result;

            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
            }

        [HttpDelete("{ID:int}")]
        public async Task<ActionResult> DeleteLeave(int ID)
        //public async Task<ActionResult<RequestLeave>> DeleteLeave(int LeaveID)
        {

            try
            {
                var result = await requestLeaveRepository.GetLeave(ID);

                if (result == null) return NotFound($"Employee with ID={ID} not found");
            var del=  await requestLeaveRepository.DeleteLeave(ID);
                return Ok(del);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }


    }
}

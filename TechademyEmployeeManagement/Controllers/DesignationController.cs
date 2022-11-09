using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Data;
using TechademyEmployeeManagement.Models;
using TechademyEmployeeManagement.Core.IService;

namespace TechademyEmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationRepository designationRepository;
        public DesignationController(IDesignationRepository designationRepository)
        {
            this.designationRepository = designationRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllDesignations()
        {
            return Ok(await designationRepository.GetAllDesignations()); 
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAllDesignations()
        //{
        //    var designation = await _context.Designation.ToListAsync();
        //    return Ok(designation);
        //}


        [HttpPost]
        public async Task<ActionResult<Designation>> AddDesignation( Designation designation)
        {
            var create = await designationRepository.AddDesignation(designation);
            return CreatedAtAction(nameof(GetAllDesignations), new { id = create.DesignationID }, create);
        }
        [HttpPut]
        public async Task<ActionResult<Designation>> UpdateDesignation(int DesignationID, Designation designation)
        {
            try
            {
                if (DesignationID != designation.DesignationID)
                    return BadRequest("ID mismatch");
                var update = await designationRepository.GetDesignation(DesignationID);
                if (update == null)
                {
                    return NotFound("Designation ID not Found");
                }
                return await designationRepository.UpdateDesignation(DesignationID, designation);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpGet("{DesignationID:int}")]
        public async Task<ActionResult<Designation>> GetDesignation(int DesignationID)
        {
            try
            {
                var result = await designationRepository.GetDesignation(DesignationID);
                if (result == null) return NotFound();
                return result;

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpDelete("{DesignationID:int}")]
        public async Task<ActionResult> DeleteDesignation(int DesignationID)
        //public async Task<ActionResult<RequestLeave>> DeleteLeave(int LeaveID)
        {

            try
            {
                var result = await designationRepository.GetDesignation(DesignationID);

                if (result == null) return NotFound($"Designation with DesignationID={DesignationID} not found");
                var del = await designationRepository.DeleteDesignation(DesignationID);
                return Ok(del);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }
    }
}

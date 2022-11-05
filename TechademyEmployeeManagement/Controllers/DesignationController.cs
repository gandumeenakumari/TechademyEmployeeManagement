using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Data;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly EmployeeContext _context;
        public DesignationController(EmployeeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDesignations()
        {
            var designation = await _context.Designation.ToListAsync();
            return Ok(designation);
        }
        [HttpPost]
        public async Task<IActionResult> AddDesignation([FromBody] Designation designation)
        {
            await _context.Designation.AddAsync(designation);
            await _context.SaveChangesAsync();
            return Ok(designation);
        }
    }
}

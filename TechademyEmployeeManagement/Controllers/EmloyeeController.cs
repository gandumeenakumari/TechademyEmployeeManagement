using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Data;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmloyeeController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly EmployeeContext _con;
        public EmloyeeController(IConfiguration configuration, EmployeeContext context)
        {
            _config = configuration;
            _con = context;
        }
        [AllowAnonymous]
        [HttpPost("createEmployee")]
        public IActionResult CreateUser(Employee employee)
        {
            if (_con.Employee.Where(u => u.Email == employee.Email).FirstOrDefault() != null)
            {
                return Ok("Already Existed");
            }
            employee.DOJ = DateTime.Now;
           _con.Employee.Add(employee);
            _con.SaveChanges();

            return Ok("Success");
        }
        [AllowAnonymous]
        [HttpPost("loginEmployee")]
        public IActionResult LoginUser(Login login)
        {
            var useravailable = _con.Employee.Where(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefault();
            if (useravailable != null)
            {
                return Ok(new JwtService(_config).GenerateToken(
                    useravailable.EmployeeID.ToString(),
                    useravailable.FirstName,
                    useravailable.LastName,
                    useravailable.Email,
                    useravailable.Mobile,
                    useravailable.Gender
                    ));
            }
            return Ok("Failure");
        }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Core.IService;
using TechademyEmployeeManagement.Data;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Core.Service
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly EmployeeContext employeeContext;

        public DesignationRepository(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        public async Task<List<Designation>> GetAllDesignations()
        {
            var hours = await employeeContext.Designation.Select(w => new
            {
                DesinationID = w.DesignationID,
               DesignationName=w.DesignationName,
               RoleName=w.RoleName,
               DepartmentName=w.DepartmentName
                
                //TotalWorkingHours = w.TotalWorkingHours

            }).ToListAsync();
            return await employeeContext.Designation.ToListAsync();
        }




        public async Task<Designation> AddDesignation(Designation designation)
        {
            var desig = await employeeContext.Designation.AddAsync(designation);
            await employeeContext.SaveChangesAsync();
            return desig.Entity;
        }




        public async Task<Designation> DeleteDesignation(int DesignationID)
        {
            var result = await employeeContext.Designation.
                FirstOrDefaultAsync(w => w.DesignationID == DesignationID);
            if (result != null)
            {
                employeeContext.Designation.Remove(result);
                await employeeContext.SaveChangesAsync();
            }
            return result;
        }

     

        public async Task<Designation> GetDesignation(int DesignationID)
        {
            
            
                return await employeeContext.Designation.
                    FirstOrDefaultAsync(l => l.DesignationID == DesignationID);
            

        }

        public void Save()
        {
            employeeContext.SaveChanges();
        }

        public async Task<Designation> UpdateDesignation(int DesignationID, Designation designation)
        {
            var result = await employeeContext.Designation
    .FirstOrDefaultAsync(w => w.DesignationID == designation.DesignationID);
            if (result != null)
            {
                result.DesignationID = designation.DesignationID;
                result.DesignationName = result.DesignationName;
                result.RoleName = result.RoleName;
                result.DepartmentName = designation.DepartmentName;
                await employeeContext.SaveChangesAsync();
                return result;
            }
            return null;
        }


       
    }
}

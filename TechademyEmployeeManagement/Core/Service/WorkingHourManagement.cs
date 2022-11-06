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
    public class WorkingHourManagement: IWorkingHourManagement
    {
        private readonly EmployeeContext employeeContext;
        public WorkingHourManagement(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }
       public async Task<List<WorkingHours>> GetTtoalWorkingHours()
        {
            var hours = await employeeContext.WorkingHours.Select(w => new
            {
                ID = w.ID,
                EmployeeID = w.EmployeeID,
                CompanyWorkingHours = w.CompanyWokingHours,
                EmployeeWorkingHours = w.EmployeeWorkingHours,
                //TotalWorkingHours = w.TotalWorkingHours

            }).ToListAsync();
            return await employeeContext.WorkingHours.ToListAsync();   
        }
        public async Task<WorkingHours> GetWorkingHour(int ID)
        {
            return await employeeContext.WorkingHours.
                FirstOrDefaultAsync(w=>w.ID==ID);
        }

        public async Task<WorkingHours> AddWorkingHours(WorkingHours workingHours)
        {
            var hours = await employeeContext.WorkingHours.AddAsync(workingHours);
            await employeeContext.SaveChangesAsync();
            return hours.Entity;
        }

        public async Task<WorkingHours> UpdateWorkingHours(int ID,WorkingHours workingHours)
        {
            var result = await employeeContext.WorkingHours
                .FirstOrDefaultAsync(w => w.ID == workingHours.ID);
            if(result!=null)
            {
                result.EmployeeID = workingHours.EmployeeID;
                result.CompanyWokingHours = workingHours.CompanyWokingHours;
                result.EmployeeWorkingHours = workingHours.EmployeeWorkingHours;
                await employeeContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async void DeleteWorkingHours(int ID)
        {
            var result = await employeeContext.WorkingHours
                .FirstOrDefaultAsync(w => w.ID == ID);
            if(result!=null)
            {
                employeeContext.WorkingHours.Remove(result);
                await employeeContext.SaveChangesAsync();
            }
        }
    }
}

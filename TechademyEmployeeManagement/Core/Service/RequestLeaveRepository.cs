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
    public class RequestLeaveRepository: IRequestLeaveRepository
    {
        private readonly EmployeeContext employeeContext;
        public RequestLeaveRepository(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        public async Task<RequestLeave> AddLeave(RequestLeave requestLeave)
        {
            var leave = await employeeContext.RequestLeave.AddAsync(requestLeave);
            await employeeContext.SaveChangesAsync();
            return leave.Entity;
        }

    

        public async Task<List<RequestLeave>> GetAllLeaves()
        {
            var hours = await employeeContext.RequestLeave.Select(w => new
            {
                
                ID = w.ID,
                LeaveType=w.LeaveType,
                  When =w.When,
                 LeaveReason =w.LeaveReason,
                
        //TotalWorkingHours = w.TotalWorkingHours

    }).ToListAsync();
            return await employeeContext.RequestLeave.ToListAsync();
        }

     

        public async Task<RequestLeave> UpdateLeave(int ID, RequestLeave requestLeave)
        {
            var result = await employeeContext.RequestLeave
     .FirstOrDefaultAsync(w => w.ID == requestLeave.ID);
            if (result != null)
            {
                result.ID = requestLeave.ID;
                result.LeaveType= requestLeave.LeaveType;
                result.When= requestLeave.When;
                result.LeaveReason= requestLeave.LeaveReason;
                
                await employeeContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<RequestLeave> GetLeave(int ID)
        {
            return await employeeContext.RequestLeave.
                FirstOrDefaultAsync(l => l.ID == ID);
        }

        public async Task<RequestLeave> DeleteLeave(int ID)
        {
            var result = await employeeContext.RequestLeave.
                FirstOrDefaultAsync(w => w.ID == ID);
            if(result!=null)
            {
                employeeContext.RequestLeave.Remove(result);
                await employeeContext.SaveChangesAsync();
            }
            return result;
        }
        public void Save()
        {
            employeeContext.SaveChanges();
        }

        
    }
}

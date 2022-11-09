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
    public class LeaveStatusRepository : ILeaveStatusRepository
    {
        private readonly EmployeeContext employeeContext;
        public LeaveStatusRepository(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        public async Task<LeaveStatus> GetStatus(int ID)
        {
            return await employeeContext.LeaveStatus.
                FirstOrDefaultAsync(l => l.ID == ID);
        }
        public async Task<LeaveStatus> AddStatus(LeaveStatus leaveStatus)
        {
            var leave = await employeeContext.LeaveStatus.AddAsync(leaveStatus);
            await employeeContext.SaveChangesAsync();
            return leave.Entity;
        }

        public async Task<LeaveStatus> DeleteStatus(int ID)
        {
            var result = await employeeContext.LeaveStatus.
                FirstOrDefaultAsync(w => w.ID == ID);
            if (result != null)
            {
                employeeContext.LeaveStatus.Remove(result);
                await employeeContext.SaveChangesAsync();
            }
            return result;
        }


        public void Save()
        {
            employeeContext.SaveChanges();
        }

        public async Task<LeaveStatus> UpdateStatus(int ID, LeaveStatus leaveStatus)
        {
            var result = await employeeContext.LeaveStatus
  .FirstOrDefaultAsync(w => w.ID == leaveStatus.ID);
            if (result != null)
            {
                result.ID = leaveStatus.ID;
                
                result.Status = leaveStatus.Status;

                await employeeContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<List<LeaveStatus>> GetAll()
        {
            var leave = await employeeContext.LeaveStatus.Select(w => new
            {

                ID = w.ID,
                
                Status = w.Status,

                //TotalWorkingHours = w.TotalWorkingHours

            }).ToListAsync();
            return await employeeContext.LeaveStatus.ToListAsync();
        }
    }
}

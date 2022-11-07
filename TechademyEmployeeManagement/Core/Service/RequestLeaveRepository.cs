﻿using Microsoft.EntityFrameworkCore;
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
                LeaveID= w.LeaveID,
                EmployeeID = w.EmployeeID,
                LeaveType=w.LeaveType,
                  When =w.When,
                 LeaveReason =w.LeaveReason,
                LeaveStatus =w.LeaveStatus,
        //TotalWorkingHours = w.TotalWorkingHours

    }).ToListAsync();
            return await employeeContext.RequestLeave.ToListAsync();
        }

     

        public async Task<RequestLeave> UpdateLeave(int LeaveID, RequestLeave requestLeave)
        {
            var result = await employeeContext.RequestLeave
     .FirstOrDefaultAsync(w => w.LeaveID == requestLeave.LeaveID);
            if (result != null)
            {
                result.EmployeeID = requestLeave.EmployeeID;
                result.LeaveType= requestLeave.LeaveType;
                result.When= requestLeave.When;
                result.LeaveReason= requestLeave.LeaveReason;
                result.LeaveStatus = requestLeave.LeaveStatus;
                await employeeContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<RequestLeave> GetLeave(int LeaveID)
        {
            return await employeeContext.RequestLeave.
                FirstOrDefaultAsync(l => l.LeaveID == LeaveID);
        }

        public async Task<RequestLeave> DeleteLeave(int LeaveID)
        {
            var result = await employeeContext.RequestLeave.
                FirstOrDefaultAsync(w => w.LeaveID == LeaveID);
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

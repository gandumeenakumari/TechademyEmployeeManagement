using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Core.IService
{
    public interface ILeaveStatusRepository
    {
        public Task<List<LeaveStatus>> GetAll();
        public Task<LeaveStatus> GetStatus(int ID);
        public Task<LeaveStatus> AddStatus(LeaveStatus leaveStatus);
        public Task<LeaveStatus> UpdateStatus(int ID, LeaveStatus leaveStatus);
        public Task<LeaveStatus> DeleteStatus(int ID);
        void Save();
    }
}

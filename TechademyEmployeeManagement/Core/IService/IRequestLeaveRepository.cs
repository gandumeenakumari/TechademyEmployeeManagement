using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Core.IService
{
    public interface IRequestLeaveRepository
    {
        public Task<List<RequestLeave>> GetAllLeaves();
        public Task<RequestLeave> GetLeave(int LeaveID);
        public Task<RequestLeave> AddLeave(RequestLeave requestLeave);
        public Task<RequestLeave> UpdateLeave(int LeaveID, RequestLeave requestLeave);
        public Task<RequestLeave> DeleteLeave(int LeaveID);
        void Save();
    }
}

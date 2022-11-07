using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Core.IService
{
    public interface IWorkingHourManagement
    {
        public Task<List<WorkingHours>> GetTtoalWorkingHours();
        public Task<WorkingHours> GetWorkingHour(int ID);
        public Task<WorkingHours> AddWorkingHours(WorkingHours workingHours);
        public Task<WorkingHours> UpdateWorkingHours(int ID,WorkingHours workingHours);
        //public void DeleteWorkingHours(int ID);
        //public  Task<WorkingHours> UpdateWorkingHours(WorkingHours workingHours);
        public Task<WorkingHours> DeleteWorkingHours(int ID);
        void Save();
    }
}

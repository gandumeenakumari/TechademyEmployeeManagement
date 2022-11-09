using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechademyEmployeeManagement.Models;

namespace TechademyEmployeeManagement.Core.IService
{
    public interface IDesignationRepository
    {
        public Task<List<Designation>> GetAllDesignations();
        public Task<Designation> GetDesignation(int DesignationID);
        public Task<Designation> AddDesignation(Designation designation);
        public Task<Designation> UpdateDesignation(int DesignationID, Designation designation);
        public Task<Designation> DeleteDesignation(int DesignationID);
        void Save();
    }
}

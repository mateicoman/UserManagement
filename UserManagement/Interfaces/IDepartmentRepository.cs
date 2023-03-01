using System;
using UserManagement.Models;

namespace UserManagement.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentModel>> GetAll();
        Task<DepartmentModel> GetDepartmentById(string departmentId);
        Task CreateDepartment(DepartmentModel department);
        Task UpdateDepartment(string departmentId, DepartmentModel department);
        Task DeleteDepartment(string departmentId);
    }
}


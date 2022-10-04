using System;
using UserManagement.Models;

namespace UserManagement.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetDepartmentById(string departmentId);
        Task CreateDepartment(Department department);
        Task UpdateDepartment(string departmentId, Department department);
        Task DeleteDepartment(string departmentId);
    }
}


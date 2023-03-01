using System;
using UserManagement.Models;
using UserManagement.Models.Requests;

namespace UserManagement.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetDepartmentById(string departmentId);
        Task CreateDepartment(CreateDepartmentRequest department);
        Task UpdateDepartment(string departmentId, UpdateDepartmentRequest department);
        Task DeleteDepartment(string departmentId);

    }
}


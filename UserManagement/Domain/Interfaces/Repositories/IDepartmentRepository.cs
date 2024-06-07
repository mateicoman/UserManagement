using UserManagement.Domain.DTOs.Department;

namespace UserManagement.Domain.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentDto>> GetAll();
        Task<DepartmentDto> GetDepartmentById(string departmentId);
        Task CreateDepartment(DepartmentDto department);
        Task UpdateDepartment(string departmentId, DepartmentDto department);
        Task DeleteDepartment(string departmentId);
    }
}


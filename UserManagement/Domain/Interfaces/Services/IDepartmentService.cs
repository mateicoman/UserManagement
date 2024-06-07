using UserManagement.Domain.DTOs.Department;

namespace UserManagement.Domain.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAll();
        Task<DepartmentDto> GetDepartmentById(string departmentId);
        Task CreateDepartment(DepartmentPostDto department);
        Task UpdateDepartment(string departmentId, DepartmentPutDto department);
        Task DeleteDepartment(string departmentId);

    }
}


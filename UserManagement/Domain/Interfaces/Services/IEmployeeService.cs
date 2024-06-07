using UserManagement.Domain.DTOs.Employee;

namespace UserManagement.Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAll();
        Task<EmployeeDto> GetEmployeeById(string employeeId);
        Task CreateEmployee(EmployeePostDto request);
        Task UpdateEmployee(string employeeId, EmployeePutDto request);
        Task DeleteEmployee(string employeeId);
    }
}


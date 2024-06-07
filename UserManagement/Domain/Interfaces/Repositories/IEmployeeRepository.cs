using UserManagement.Domain.DTOs.Employee;

namespace UserManagement.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAll();
        Task<EmployeeDto> GetEmployeeById(string employeeId);
        Task CreateEmployee(EmployeeDto employee);
        Task UpdateEmployee(string employeeId, EmployeeDto employee);
        Task DeleteEmployee(string employeeId);
    }
}

